# Build An Alexa Fact Skill in C#
![](https://m.media-amazon.com/images/G/01/mobile-apps/dex/alexa/alexa-skills-kit/tutorials/fact/header._TTH_.png)

[![Voice User Interface](https://m.media-amazon.com/images/G/01/mobile-apps/dex/alexa/alexa-skills-kit/tutorials/navigation/1-off._TTH_.png)](step-by-step/1-voice-user-interface.md)[![Lambda Function](https://m.media-amazon.com/images/G/01/mobile-apps/dex/alexa/alexa-skills-kit/tutorials/navigation/2-off._TTH_.png)](step-by-step/2-lambda-function.md)[![Connect VUI to Code](https://m.media-amazon.com/images/G/01/mobile-apps/dex/alexa/alexa-skills-kit/tutorials/navigation/3-off._TTH_.png)](step-by-step/3-connect-vui-to-code.md)[![Testing](https://m.media-amazon.com/images/G/01/mobile-apps/dex/alexa/alexa-skills-kit/tutorials/navigation/4-off._TTH_.png)](step-by-step/4-testing.md)

## What You Will Learn
*  [AWS Lambda](http://aws.amazon.com/lambda)
*  [Alexa Skills Kit (ASK)](https://developer.amazon.com/alexa-skills-kit)
*  Using the [Skill builder (beta)](https://developer.amazon.com/public/solutions/alexa/alexa-skills-kit/docs/ask-define-the-vui-with-gui)
*  Voice User Interface (VUI) Design
*  The [Dialog.Delegate directive](https://developer.amazon.com/public/solutions/alexa/alexa-skills-kit/docs/dialog-interface-reference#directives)

## What You Will Need
*  [Amazon Developer Portal Account](http://developer.amazon.com)
*  [Amazon Web Services Account](http://aws.amazon.com/)
*  The sample code on [GitHub](./sampleFactCsharp)
*  A computer running a supported OS (Windows 10, Windows 8, or Windows 7)
*  A basic understanding of C#

## What Your Skill Will Do
A fact skill for Alexa is a "Hello, World" example.  You provide a list of interesting facts about a topic, and Alexa will read one of those facts to your user when they start your skill.  The purpose of building this skill is to teach you how the different pieces of the Alexa development process fit together.

The Skill builder's new dialog model significantly reduces the amount of code and data handling required to manage slot's, prompts and confirmations in custom intents. As a developer all you need to do is implement the Dialog.Delegate directive if the received dialog status is not complete. Alexa will manage all of the dialog and information capture for you up to that point.

In this skill sample we have implemented the Dialog.Delegate directive in two custom intents, a simple space travel planner, and a planetary weather query.


<a href="step-by-step/1-voice-user-interface.md"><img src="https://m.media-amazon.com/images/G/01/mobile-apps/dex/alexa/alexa-skills-kit/tutorials/general/buttons/button_get_started._TTH_.png" /></a>
