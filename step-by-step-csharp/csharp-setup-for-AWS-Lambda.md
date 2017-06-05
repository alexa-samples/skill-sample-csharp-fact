## Setting up your AWS Lambda C# development environment
To use the C# for AWS Lambda development a number of components must be installed in your development environment.

1.  **Visual Studio 2017**. Use Microsoft Visual Studio to develop your C# AWS Lambda function. Microsoft Visual Studio Community is available for free from https://www.visualstudio.com/vs/. Microsoft Visual Studio 2017 is the version used in the examples.

2.  The **AWS Toolkit for Visual Studio 2017**. Download the latest version of [AWS Toolkit for Visual Studio](https://aws.amazon.com/visualstudio/). If you have not already done so you will need to create an **AWS account** and a **user profile** which will be used by Visual Studio to upload your projects to AWS Lambda. Detailed information and step by step instructions on how install the Toolkit and configure your account can be found in the following article [Setting Up the Toolkit for Visual Studio](http://docs.aws.amazon.com/toolkit-for-visual-studio/latest/user-guide/getting-set-up.html).

3.  An installed version of the **DotNetCore SDK**.
AWS Lambda uses .NET Core 1.0 to execute C# code so download and install the latest Microsoft .NET Core 1.0+ version at https://www.microsoft.com/net/download/core#/runtime. Do not install any version higher than .NET Core 1.0.

4. When the above components have been installed download the [sample C# solution](./sampleFactCsharp/) and load the solution into Visual Studio. Ensure that the solution builds. A successful build will create a _sampleFactCsharp.dll_ file.

5. Before we can publish we must **configure an account in Visual Studio**. With the details provided in step 2 above, open the **AWS Explorer** window in Visual Studio and select the **New Account Profile** icon. Complete all the fields in the **New Account Profile Dialog**, these include the Access Key Id, Secret Access Key and Account Number. Select the **Ok** button to save. Make sure that the selected region is set to **US East (Virginia)** in the **Region** dropdown in the AWS Explorer. You should now be logged in.

    ![](setup-fig1.png)

6. To publish your C# Function select the **Publish to AWS Lambda** menu option. In the **Upload to AWS Lambda** window titled **Upload Lambda Function** you may wish to tick the _Save settings to aws-lamda-tools-default.json for future deployment_ option, otherwise click **Next**. In the **Advanced Function Details** window set a role in the **Role Name** dropdown, if none has been pre-configured select **AWSLamdaBasicExecutionRole**, click **Upload** to start the publishing process.

    ![](setup-fig2.png)

    ![](setup-fig3.png)

    ![](setup-fig4.png)

7. When the upload completes a Lambda test screen should appear. Here you can test basic functionality of your C# Lambda Function. Select **Alexa Start Session** from the **Example Request** dropdown and click the **Invoke** button. A **LaunchRequest** will be sent to your Function, if the **Response** window displays **"null", or "The remote endpoint could not be called, or the response it returned was invalid"** this is an indication that something is broken. AWS Lambda offers an additional testing tools to help you troubleshoot your skill.

  ![](setup-fig6.png)


To enable your C# Lambda Function to be invoked from an Alexa Skill you must add an **Alexa Skills Kit Trigger** then link the Function's ARN value to an Alexa Skill. This process is described in detail on [Page 2](../step-by-step/2-lambda-function.md) of the Step-by-step tutorial for this sample skill.
