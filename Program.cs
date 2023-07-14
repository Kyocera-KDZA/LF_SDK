namespace LF_SDK
{
    using Laserfiche.Workflow;
    using Laserfiche.Workflow.Objects;
    internal class Program
    {
        static void Main(string[] args)
        {
            string workflowServer = "localhost";
            string workflowApplication = "Chris Workflow Application";

            using (WorkflowConnection connection = WorkflowConnection.CreateConnection(workflowServer, workflowApplication))
            {
                string workflowName = "TODO: Your workflow name here";
                Database database = connection.Database;
                PublishedWorkflow workflow = database.GetPublishedWorkflow(workflowName);

                // The starting rule for this workflow (it can be made up).
                string ruleName = "Hello World";

                // The starting entry for the workflow, this can be null.
                // Pick an entry in your repository and fill in the correct repository,
                // server, entry id, and path.
                // The Entry Guid can be incorrect, but some workflow features
                // may not work correctly.
                StartingEntry entry = new StartingEntry();
                entry.Id = 1234;
                entry.FullPath = "\\My Entry Path";
                entry.Repository = "MyLaserficheRepository";
                entry.Server = "MyLaserficheServer";
                entry.EntryGuid = Guid.Empty; 


                // The initiator of the workflow, it can be null.
                Initiator initiator = null;

                // Options for creating the workflow, this can be null.
                WorkflowCreationOptions options = new WorkflowCreationOptions();

                // Optional parameters to the workflow, they are available as tokens.
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                workflow.StartWorkflow(ruleName, entry, initiator, options, parameters);
            }

            //using WorkflowConnection connection = WorkflowConnection.CreateConnection(workflowServer, workflowApplication);

        }
    }
}