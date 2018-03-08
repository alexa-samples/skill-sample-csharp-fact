# Build An Alexa Fact Skill
[![Voice User Interface](https://m.media-amazon.com/images/G/01/mobile-apps/dex/alexa/alexa-skills-kit/tutorials/navigation/1-on._TTH_.png)](1-voice-user-interface.md)[![Lambda Function](https://m.media-amazon.com/images/G/01/mobile-apps/dex/alexa/alexa-skills-kit/tutorials/navigation/2-off._TTH_.png)](2-lambda-function.md)[![Connect VUI to Code](https://m.media-amazon.com/images/G/01/mobile-apps/dex/alexa/alexa-skills-kit/tutorials/navigation/3-off._TTH_.png)](3-connect-vui-to-code.md)[![Testing](https://m.media-amazon.com/images/G/01/mobile-apps/dex/alexa/alexa-skills-kit/tutorials/navigation/4-off._TTH_.png)](4-testing.md)

## Setting up Your Alexa Skill in the Developer Portal
1.  **Go to the [Amazon Developer Portal](http://developer.amazon.com).  In the top-right corner of the screen, click the "Sign In" button.** </br>(If you don't already have an account, you will be able to create a new one for free.)


2.  Once you have signed in, move your mouse over the **Your Alexa Consoles** text at the top of the screen and Select the **Skills (New)** Link.


3.  From the **Alexa Skills Console (New Console)** select the **Create Skill** button near the top of the screen.


4. Give your new skill a **Name**. This is the name that will be shown in the Alexa Skills Store, and the name your users will refer to. Push Next.

5. Select the **Custom** model at the top of the page to add to your skill and select the **Create Skill** button at the top right.

6. **Build the Interaction Model for your skill**
	1. On the left hand navigation panel. Select the **Invocation** tab. Enter a **Skill Inovcation Name**. This is the name that your users will need to say to start your skill.
	2. Next, select the **JSON Editor** tab. In the textfield provided, replace any existing code with the code provided in the [Interaction Model](../interactionModel.json), then click "Build Model".

	**Note:** You should notice that **Intents** and **Slot Types** will auto populate based on the JSON Interaction Model that you have now applied to your skill. Feel free to explore the changes here, to learn about **Intents**, **Slots**, and **Utterances** open our [technical documentation in a new tab](https://developer.amazon.com/docs/custom-skills/define-the-interaction-model-in-json-and-text.html).

7. **Optional:** Select an intent by expanding the **Intents** from the left side navigation panel. Add some more sample utterances for your newly generated intents. Think of all the different ways that a user could request to make a specific intent happen. A few examples are provided. Be sure to click **Save Model** and **Build Model** after you're done making changes here.


     If you get an error from your interaction model, check through this list:

     *  **Did you copy & paste the provided code correctly?**
     *  **Did you accidentally add any characters to the Interaction Model or Sample Utterances?**

8.  Click on the **Add+** button near __Intents__ on the left of the dashboard.

9.  In the textbox provided, enter the new intent name: **GetNewFactIntent**, and click the **Create Intent** button.


10. Add sample utterances for your intent. These are the things a user would say to make this intent happen. Here are a few examples:

    * Space fact
    * Tell me a fact
    * Tell me something
    * Tell me a space fact
    * Give me a space fact
    * Give me a fact


11. Click on the **Save Model** button, and then click on the **Build Model** button.

    If the model builds successfully we can move on and add more Intents to the application in step 12. If you get an error from the Interaction Model then check the following::

    * Did you copy and paste the provided code into the appropriate boxes?
    * Did you accidentally add any characters to the Interaction Model or Sample Utterances?
    <br/>


12. Click on the "Add+" button near **Intents** on the top left corner of the dashboard.


    In the textbox provided enter the new intent name, **GetJoke**, and click the **Create Intent** button.


13. Add some sample utterances for your intent. These are the things a user would say to make the **GetJoke** intent happen. Here are a few possible examples:

      * Tell me a joke
      * Next joke
      * A joke please
      * Give me a joke
      * Make me laugh

      Click the **Save Model** button to save your data, don't click the **Build Model** button just yet as we have more Intents to configure.


14. We will now create the "GetTravelTime" custom intent. Click **Add Intent** as described above and enter **GetTravelTime** then click the **Create Intent** button. Now add some utterances for the GetTravelTime intent, enter the following:

    * calculate travel time
    * how long does it take to travel from {DepartingPlanet} to {ArrivingPlanet}

    Click **Save Model**.

      Notice the Intent Slots panel has the new slots that were created while adding utterances. Tick the DepartingPlanet and ArrivingPlanet checkboxes to indicate that these are required slots.


15. Next we will create a custom slot type called **Planet** which will contain a list of all the planets the user can travel too. Whenever possible choose from one of the built in slot types as those are already trained for you. To create a custom slot type, look for the **Slot Types** section on the navigation panel and choose ```ADD+``` to bring up the Add Slot Type page.

    Type **Planet** as the slot name then click the **Create Slot Type** button and enter the following slot values:

    ```
    Mercury
    Venus
    Earth
    Mars
    Jupiter
    Saturn
    Uranus
    Neptune
    Pluto
    ```

16. Now set the slot type for the DepartingPlanet and ArrivingPlanet Intent Slots to the **Planet** slot type just created. Under the **Intent Slots** panel on the left click the **Edit** icon to display the **DepartingPlanet** Intent Slot details window.  From the **Slot Type** dropdown select **Planet**. Repeat the above for the **ArrivingPlanet**.

    Click **Save Model**.

    If the model saves successfully, move on to the next step. If you get an error from the such as _Bad Request_, check that you properly assigned the **DepartingPlanet** and **ArrivingPlanet** Slot Types to **Planet**.

17. Next we'll add **Prompts** and **Utterances** to both the DepartingPlanet and ArrivingPlanet Intent Slots. Open the Intent Slot details windows for DepartingPlanet as above. Set the **Is this slot required to fulfill the intent** option to **YES**. Add the prompts that Alexa will employ to request the DepartingPlanet from user, enter the following as a prompt:

    * Which planet are you starting from?

    followed by the list of utterances that users might respond with:

    * I'm starting from {DepartingPlanet}
    * {DepartingPlanet}
    * I'm going from {DepartingPlanet} to {ArrivingPlanet}

    Click **Save Model**.

    > Notice that you can enable the user to over answer with other slot values. That helps the experience to be more conversational rather than feeling like a wizard.

    Leave **Does this slot require confirmation?** set to **NO**. You would set this to YES if Alexa was needed to say something like "Are you sure?" after gathering the slot value. This approach will be demonstrated in the GetWeather Intent.

    Now repeat for the ArrivingPlanet Intent Slot. Set the **Is this slot required to fulfill the intent** radio button to **YES**. Add the following prompt text:

    * Which planet are you going to?

    then add the utterances that users might respond with:

    * {ArrivingPlanet}
    * I'm going to {ArrivingPlanet}

    As before, leave Slot Confirmation set to **NO**.

    Click **Save Model**.

19. Create and configure the **GetWeather** Intent. As before, add a new Intent and call it **GetWeather**, then add utterances such as:

    * Tell me weather
    * Weather at {Planet}
    * Tell me weather at {Planet}
    * What is weather
    * What is weather at {Planet}

    Next, edit the Intent Slot called **Planet** that has been created in the Intent Slots panel on the left of the display by clicking the **Edit icon**. In the Slot Type dropdown select **Planet**. Set the **Is this slot required to fulfill the intent** option to **YES**. Then enter the following strings in the **Prompts** field:

    * Weather at which planet?
    * Which planet?
    * Which planet's weather do you want to know?

    In the **Slot Confirmation** panel set the **Does this slot require confirmation?** option to **YES**. Then add the following text to the prompts field:

    * Are you certain?
    * Do you want to know the weather at {Planet}?

    These prompts will allow Alexa to query the user after gathering the slot value.

20. We have now finished configuring the **GetWeather** Intent. Click on **Save Model** to save your data, then click **Build Model** to build it. It may take a few minutes for the model to build, when finished click **Configuration** to move to Configuration.

    If you get an error from your interaction model, check through this list:
    * Did you copy & paste the provided code into the appropriate boxes?
    * Did you accidentally add any characters to the Interaction Model or Sample Utterances?

    In the next step of this guide, we will create our Lambda function in the AWS developer console but keep Amazon Developer Console available as you will return to it in a later step.

<br/><br/>
<a href="2-lambda-function.md"><img src="https://m.media-amazon.com/images/G/01/mobile-apps/dex/alexa/alexa-skills-kit/tutorials/general/buttons/button_next_lambda_function._TTH_.png" /></a>
