# Build An Alexa Fact Skill
[![Voice User Interface](https://m.media-amazon.com/images/G/01/mobile-apps/dex/alexa/alexa-skills-kit/tutorials/navigation/1-locked._TTH_.png)](1-voice-user-interface.md)[![Lambda Function](https://m.media-amazon.com/images/G/01/mobile-apps/dex/alexa/alexa-skills-kit/tutorials/navigation/2-on._TTH_.png)](2-lambda-function.md)[![Connect VUI to Code](https://m.media-amazon.com/images/G/01/mobile-apps/dex/alexa/alexa-skills-kit/tutorials/navigation/3-off._TTH_.png)](3-connect-vui-to-code.md)[![Testing](https://m.media-amazon.com/images/G/01/mobile-apps/dex/alexa/alexa-skills-kit/tutorials/navigation/4-off._TTH_.png)](4-testing.md)

## Setting Up A Lambda Function Using Amazon Web Services
In the [first step of this guide](1-voice-user-interface.md), we built the Voice User Interface (VUI) for our Alexa skill. You can [read more about what a Lambda function is](http://aws.amazon.com/lambda), but for the purposes of this guide, what you need to know is that Lambda is where our code lives.  When a user asks Alexa to use our skill, it is our Lambda function that interprets the appropriate interaction, and provides the conversation back to the user.

1. Review and **implement the [C# Setup Instructions for AWS Lambda](../step-by-step-csharp/csharp-setup-for-AWS-Lambda.md)** to setup the Lambda via Visual Studio.

2. Go to http://aws.amazon.com and sign in to the console.

3.  Next we must create a **Trigger** to enable the C# Lambda Function previously uploaded to be triggered from an Alexa Skill. Select the **Alexa Skills Kit** option in the left _Add Triggers_ panel. An **Alexa Skills Kit** trigger is added with a _Configuration Required_ information alert.  

    ![](2-lambda-fig0.png)

4. Copy the Skill ID of the _Sample Fact Skill - C#_ from the Amazon Developer Console. The ID is at the top of the Skill Information page and has the format of amzn1.ask.skill.XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX. Copy this value into required the Skill ID input box in the _Configure triggers_ section of the _sampleFactCsharp_ Lambda function page.

    ![](2-lambda-skill-id.png)

5. The final step, is to copy the Skill ID ARN (Amazon Resource Name) value from the top right corner of the _sampleFactCsharp_ Lambda function page. It has the format ```arn:aws:lambda:us-east-1:############:function:sampleFactCsharp```. You will need this value in the next section of this guide.

<br/><br/>
<a href="3-connect-vui-to-code.md"><img src="https://m.media-amazon.com/images/G/01/mobile-apps/dex/alexa/alexa-skills-kit/tutorials/general/buttons/button_next_connect_vui_to_code._TTH_.png"/></a>
