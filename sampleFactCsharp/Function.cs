using System;
using System.Collections.Generic;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using AlexaAPI;
using AlexaAPI.Request;
using AlexaAPI.Response;
using System.IO;
using System.Text.RegularExpressions;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializerAttribute(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace sampleFactCsharp
{
    public class Function
    {
        private SkillResponse response = null;
        private static List<FactData> resources = null;
        private ILambdaContext context = null;
        const string LOCALENAME = "locale";
        const string USA_Locale = "en-US";
        const string PLANETS = "Planet";
        const string DEPARTINGPLANET = "DepartingPlanet";
        const string ARRIVINGPLANET  = "ArrivingPlanet";

        static Random rand = new Random();

        /// <summary>
        /// Application entry point
        /// </summary>
        /// <param name="input"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext ctx)
        {
            context = ctx;
            try
            {
                response = new SkillResponse();
                response.Response = new ResponseBody();
                response.Response.ShouldEndSession = false;
                response.Version = AlexaConstants.AlexaVersion;

                if (input.Request.Type.Equals(AlexaConstants.LaunchRequest))
                {
                    string locale = input.Request.Locale;
                    if (string.IsNullOrEmpty(locale))
                    {
                        locale = USA_Locale;
                    }

                    var facts = GetFacts(locale);
                    ProcessLaunchRequest(facts, response.Response);
                    response.SessionAttributes = new Dictionary<string, object>() {{LOCALENAME, locale}};
                }
                else
                {
                    if (input.Request.Type.Equals(AlexaConstants.IntentRequest))
                    {
                       string locale = string.Empty;
                       Dictionary <string, object> dictionary = input.Session.Attributes;
                       if (dictionary != null)
                       {
                           if (dictionary.ContainsKey(LOCALENAME))
                           {
                               locale = (string) dictionary[LOCALENAME];
                           }
                       }
               
                       if (string.IsNullOrEmpty(locale))
                       {
                            locale = input.Request.Locale;
                       }

                       if (string.IsNullOrEmpty(locale))
                       {
                            locale = USA_Locale; 
                       }

                       response.SessionAttributes = new Dictionary<string, object>() {{LOCALENAME, locale}};
                       var facts = GetFacts(locale);

                       if (IsDialogIntentRequest(input))
                       {
                            if (!IsDialogSequenceComplete(input))
                            { // delegate to Alexa until dialog is complete
                                CreateDelegateResponse();
                                return response;
                            }
                       }

                       if (!ProcessDialogRequest(facts, input, response))
                       {
                           response.Response.OutputSpeech = ProcessIntentRequest(facts, input);
                       }
                    }
                }
                Log(JsonConvert.SerializeObject(response));
                return response;
            }
            catch (Exception ex)
            {
                Log($"error :" + ex.Message);
            }
            return null; 
        }

        /// <summary>
        /// Process and respond to the LaunchRequest with launch
        /// and reprompt message
        /// </summary>
        /// <param name="factdata"></param>
        /// <param name="response"></param>
        /// <returns>void</returns>
        private void ProcessLaunchRequest(FactData factdata, ResponseBody response)
        {
            if (factdata != null)
            {
                IOutputSpeech innerResponse = new SsmlOutputSpeech();
                (innerResponse as SsmlOutputSpeech).Ssml = SsmlDecorate(factdata.LaunchMessage);
                response.OutputSpeech = innerResponse;
                IOutputSpeech prompt = new PlainTextOutputSpeech();
                (prompt as PlainTextOutputSpeech).Text = factdata.LaunchMessageReprompt;
                response.Reprompt = new Reprompt()
                {
                    OutputSpeech = prompt
                };
            }
        }

        /// <summary>
        /// Check if its IsDialogIntentRequest, e.g. part of a Dialog sequence
        /// </summary>
        /// <param name="input"></param>
        /// <returns>bool true if a dialog</returns>
        private bool IsDialogIntentRequest(SkillRequest input)
        {
            if (string.IsNullOrEmpty(input.Request.DialogState))
                return false;
            return true;
        }

        /// <summary>
        /// Check if its Dialog sequence is complete
        /// </summary>
        /// <param name="input"></param>
        /// <returns>bool true if dialog complete set</returns>
        private bool IsDialogSequenceComplete(SkillRequest input)
        {
            if (input.Request.DialogState.Equals(AlexaConstants.DialogStarted)
               || input.Request.DialogState.Equals(AlexaConstants.DialogInProgress))
            { 
                return false ;
            }
            else
            {
                if (input.Request.DialogState.Equals(AlexaConstants.DialogCompleted))
                {
                    return true;
                }
            }
            return false;
        }

        // <summary>
        ///  Process intents that are dialog based and may not have a speech
        ///  response. Speech responses cannot be returned with a delegate response
        /// </summary>
        /// <param name="factdata"></param>
        /// <param name="input"></param>
        /// <param name="response"></param>
        /// <returns>bool true if processed</returns>
        private bool ProcessDialogRequest(FactData factdata, SkillRequest input, SkillResponse response)
        {
            var intentRequest = input.Request;
            string speech_message = string.Empty;
            bool processed = false;

            switch (intentRequest.Intent.Name)
            {
                case "GetWeather":
                    speech_message = GetWeather(factdata, intentRequest);
                    if (!string.IsNullOrEmpty(speech_message))
                    {
                        response.Response.OutputSpeech = new SsmlOutputSpeech();
                        (response.Response.OutputSpeech as SsmlOutputSpeech).Ssml = SsmlDecorate(speech_message);
                    }
                    processed = true;
                    break;

                case "GetTravelTime":
                    speech_message =  GetTravelTime(factdata, intentRequest);
                    if (!string.IsNullOrEmpty(speech_message))
                    {
                        response.Response.OutputSpeech = new SsmlOutputSpeech();
                        (response.Response.OutputSpeech as SsmlOutputSpeech).Ssml = SsmlDecorate(speech_message);
                    }
                    processed = true;
                    break;
            }

            return processed;
        }

        /// <summary>
        ///  prepare text for Ssml display
        /// </summary>
        /// <param name="speech"></param>
        /// <returns>string</returns>
        private string SsmlDecorate(string speech)
        {
            return "<speak>" + speech + "</speak>";
        }

        /// <summary>
        /// Process all not dialog based Intents
        /// </summary>
        /// <param name="factdata"></param>
        /// <param name="input"></param>
        /// <returns>IOutputSpeech innerResponse</returns>
        private IOutputSpeech ProcessIntentRequest(FactData factdata, SkillRequest input)
        {
            var intentRequest = input.Request;
            IOutputSpeech innerResponse = new PlainTextOutputSpeech();
            
            switch (intentRequest.Intent.Name)
            {
                case "GetNewFactIntent":
                    innerResponse = new SsmlOutputSpeech();
                    (innerResponse as SsmlOutputSpeech).Ssml = GetNewFact(factdata, true);
                    break;
                case "GetJoke":
                    innerResponse = new SsmlOutputSpeech();
                    (innerResponse as SsmlOutputSpeech).Ssml = GetJoke(factdata);
                    break;
                case AlexaConstants.CancelIntent:
                    (innerResponse as PlainTextOutputSpeech).Text = factdata.StopMessage;
                    response.Response.ShouldEndSession = true;
                    break;

                case AlexaConstants.StopIntent:
                    (innerResponse as PlainTextOutputSpeech).Text = factdata.StopMessage;
                    response.Response.ShouldEndSession = true;                    
                    break;

                case AlexaConstants.HelpIntent:
                    (innerResponse as PlainTextOutputSpeech).Text = factdata.HelpMessage; 
                    break;

                default:
                    (innerResponse as PlainTextOutputSpeech).Text = factdata.HelpReprompt; 
                    break;
            }
            if (innerResponse.Type == AlexaConstants.SSMLSpeech)
            {
                BuildCard(factdata.SkillName, (innerResponse as SsmlOutputSpeech).Ssml);
                (innerResponse as SsmlOutputSpeech).Ssml = SsmlDecorate((innerResponse as SsmlOutputSpeech).Ssml);
            }  
            return innerResponse;
        }

        /// <summary>
        /// Build a simple card, setting its title and content field 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns>void</returns>
        private void BuildCard(string title, string output)
        {
            if (!string.IsNullOrEmpty(output))
            {                
                output = Regex.Replace(output, @"<.*?>", "");
                response.Response.Card = new SimpleCard()
                {
                    Title = title,
                    Content = output,
                };  
            }
        }

        /// <summary>
        ///  Get planetary travel time. Delegate to the dialog
        ///  if the "Complete" protocol flag is not set
        /// </summary>
        /// <param name="factdata"></param>
        /// <param name="request"></param>
        /// <returns>string of travel time</returns>
        private string GetTravelTime(FactData factdata, Request request)
        {
            string speech_message = string.Empty;
           
            Slot departslot;
            if (request.Intent.Slots.TryGetValue(DEPARTINGPLANET, out departslot))
            { 
              Slot arriveslot;
              if (request.Intent.Slots.TryGetValue(ARRIVINGPLANET, out arriveslot))
              {
                 var p1 = departslot.Value.ToLower();
                 var p2 = arriveslot.Value.ToLower();

                 if (factdata.Planets.ContainsKey(p1) && factdata.Planets.ContainsKey(p2))
                 {
                    Planet fromplanet = factdata.Planets[p1];
                    Planet toplanet = factdata.Planets[p2];

                    speech_message = "It would take about ";
                    var distance = Math.Abs(fromplanet.ftDistanceFromSun - toplanet.ftDistanceFromSun);
                    var speedOfTravel = factdata.Vehicles["rocket"].ftSpeed;

                    var travelTimeHours = (distance * 1000000) / speedOfTravel;
                    if (travelTimeHours < 24)
                    {
                       var travelTimeMinutes = Math.Round(travelTimeHours * 60);
                       speech_message += travelTimeMinutes + " minutes";
                    }
                    else if (travelTimeHours > 8760)
                    {
                        var travelTimeYears = (travelTimeHours / 8760).ToString("0.##");
                        speech_message += travelTimeYears + " years";
                    }
                    else if (travelTimeHours > 730)
                    {
                        var travelTimeMonths = (travelTimeHours / 730).ToString("0.##");
                        speech_message += travelTimeMonths + " months";
                    }
                    else if (travelTimeHours > 24)
                    {
                        var travelTimeDays = (travelTimeHours / 24).ToString("0.##");
                        speech_message += travelTimeDays + " days";
                    }
                    else
                    {
                       speech_message += travelTimeHours + " hours";
                    }
                    speech_message += " to travel from " + fromplanet.PrintName + " to "  
                    +toplanet.PrintName + " " + factdata.Vehicles["rocket"].VehicleType + "." +
                    factdata.AskMessage;
                 }
                 else
                    {
                        speech_message = InvalidSlotMessage(factdata, p1, p2);
                    }
               }
            }
            return speech_message;
        }
               
        /// <summary>
        ///  Get weather information for a planet. Delegate to the dialog
        ///  if the Complete protocol flag is not set
        /// </summary>
        /// <param name="factdata"></param>
        /// <param name="request"></param>
        /// <returns>string weather newfact or empty string</returns>
        private string GetWeather(FactData factdata, Request request)
        {
            string speech_message = string.Empty;
            if (request.Intent.Slots.ContainsKey(PLANETS))
            {
                Slot slot = null;
                if (request.Intent.Slots.TryGetValue(PLANETS, out slot))
                {
                    if (slot.Value != null && factdata.Planets.ContainsKey(slot.Value.ToLower()))
                    {
                        Planet planet = factdata.Planets[slot.Value.ToLower()];
                        speech_message = "The forecast for " + planet.PrintName + " is " + planet.Weather +
                                          factdata.AskMessage;
                    }
                    else
                    {
                        speech_message = InvalidSlotMessage(factdata, slot.Value, "");
                    }
                }
            }
            return speech_message;
        }

        /// <summary>
        ///  create a delegate response, we delegate all the dialog requests
        ///  except "Complete"
        /// </summary>
        /// <returns>void</returns>
        private void CreateDelegateResponse()
        {
            DialogDirective dld = new DialogDirective()
            {
                Type = AlexaConstants.DialogDelegate
            };
            response.Response.Directives.Add(dld);
        }

        /// <summary>
        ///  create a invalid slot value message        
        /// </summary>
        /// <param name="factdata"></param>
        /// <param name="departKey"></param>
        /// <param name="arriveKey"></param>
        /// <returns>string invalid planet name or empty string</returns>
        private string InvalidSlotMessage(FactData factdata, string departKey, string arriveKey)
        {
            string output = String.Empty;
            if (!factdata.Planets.ContainsKey(departKey))
            {
                output = "There is no planet by name " + departKey + ", would you please provide a valid planet name ? " +
                          factdata.HelpMessage;                
            }
            else if (!factdata.Planets.ContainsKey(arriveKey))
            {
                output = "There is no planet by name " + arriveKey + ", would you please provide a valid planet name ? " +
                          factdata.HelpMessage ;                
            }            
            return output;
        }

        /// <summary>
        ///  Get a new random fact from the fact list.
        /// </summary>
        /// <param name="factdata"></param>
        /// <param name="withPreface"></param>
        /// <returns>string newfact</returns>
        private string GetNewFact(FactData factdata, bool withPreface)
        {
            string preface = string.Empty;
            if (factdata == null)
            {
                return string.Empty;
            }

            if (withPreface)
            {
                preface = factdata.GetFactMessage;
            }

            return preface + factdata.Facts[rand.Next(factdata.Facts.Count)] + factdata.AskMessage;
        }

        /// <summary>
        ///  Get a new random joke, are these funny?
        /// </summary>
        /// <param name="factdata"></param>
        /// <returns>string joke</returns>
        private string GetJoke(FactData factdata)
        {
            return factdata.Jokes[rand.Next(factdata.Jokes.Count)] + factdata.AskMessage;
        }


        /// <summary>
        /// Get the fatcs and questions for the specified locale
        /// </summary>
        /// <param name="locale"></param>
        /// <returns>factdata for the locale</returns>
        private FactData GetFacts(string locale)
        {
            if (resources == null)
            {
                resources = FactData.LoadFacts();
            }

            if (string.IsNullOrEmpty(locale) )
            {
                locale = USA_Locale; 
            }

            foreach (FactData factdata in resources)
            {
                if( factdata.Locale.Equals(locale) )
                {
                    return factdata;
                }
            }
            return null;
        }

        /// <summary>
        /// logger interface
        /// </summary>
        /// <param name="text"></param>
        /// <returns>void</returns>
        private void Log(string text)
        {
            if (context != null)
            {
                context.Logger.LogLine(text);
            }
        }
    }
}
