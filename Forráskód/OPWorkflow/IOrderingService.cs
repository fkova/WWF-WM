using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.Activities;

namespace OPWorkflow
{
    // OPWorkflow-tól a Host felé történő üzenetek átadására szolgáló interfész
    [ExternalDataExchange]
    public interface IOrderingService
    {
        void WorkflowToHost(string message);
    }
}
