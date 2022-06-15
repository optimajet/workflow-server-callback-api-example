# Callback API Sample

This is a sample of a Web Api server for working with the WorkflowServer Callback API. 
Callback API allows hosting your code of Actions, Conditions or Rules on third-party servers. 
Callback server should be connected in the admin panel on the Callback API page. 
More details on the [workflowserver.io](https://workflowserver.io/documentation/callback-api).

## What's inside

- **ApiController** – controller that implements all possible requests from Callback API of WFS 3.0.0.
- **ActionProvider, ConditionProvider, IdentityProvider** – a sample of the implementation of API functions.
- **VacationRequest** is a schema that implements this API.

## How to start

- Download, deploy and start WorkflowServer. More details on the [workflowserver.io](https://workflowserver.io/documentation/how-to-launch)
- Deploy and start this Web Api Server.
- Go to the WorkflowServer, in the sidebar go to "Api" -> "Callback API". Set up a connection properties to this API. 
More details on the [workflowserver.io](https://workflowserver.io/documentation/callback-api)
- In the sidebar, go to "Workflow" -> "Scheme Management" -> "Create". 
Create a scheme, name it "VacationRequest" and upload the `Schemes/VacationRequest.xml` file from API project to the Scheme.
- You can now test this sample with the WorkflowApi.
Just create an instance, you can change the initial parameters if you like. Use the Workflow API to execute commands.
Learn more about [workflowserver.io](https://workflowserver.io/documentation/workflow-api)