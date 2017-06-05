using System;

namespace AlexaAPI
{
    // see https://developer.amazon.com/public/solutions/alexa/alexa-skills-kit/docs/dialog-interface-reference#delegate
    public static class AlexaConstants
    {
        public const string DialogDelegate = "Dialog.Delegate";
        public const string DialogElicitSlot = "Dialog.ElicitSlot";
        public const string DialogConfirmSlot = "Dialog.ConfirmSlot";
        public const string DialogConfirmIntent = "Dialog.ConfirmIntent";

        public const string DialogCompleted  = "COMPLETED";
        public const string DialogStarted    = "STARTED";
        public const string DialogInProgress = "IN_PROGRESS";
        
        public const string CancelIntent = "AMAZON.CancelIntent";
        public const string HelpIntent = "AMAZON.HelpIntent";
        public const string StopIntent = "AMAZON.StopIntent";
        public const string StartOverIntent = "AMAZON.StartOverIntent";
        public const string LaunchRequest = "LaunchRequest";
        public const string IntentRequest = "IntentRequest";
        public const string SessionEndedRequest = "SessionEndedRequest";
        public const string NoIntent = "AMAZON.NoIntent";
        public const string YesIntent = "AMAZON.YesIntent";
        public const string RepeatIntent = "AMAZON.RepeatIntent";
        public const string PauseIntent = "AMAZON.PauseIntent";
        public const string PreviousIntent = "AMAZON.PreviousIntent";
        public const string NextIntent = "AMAZON.NextIntent";
        
        public const string SSMLSpeech = "SSML";
        public const string PlainText  = "PlainText";
        
        public const string AlexaVersion = "1.0";
    }
}

