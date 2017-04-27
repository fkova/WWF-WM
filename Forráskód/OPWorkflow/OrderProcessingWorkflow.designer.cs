using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace OPWorkflow
{
    partial class OrderProcessingWorkflow
    {
        #region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("", "")]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding4 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference2 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding5 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding6 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.UpdateHistory2 = new System.Workflow.Activities.CodeActivity();
            this.delay3s = new System.Workflow.Activities.DelayActivity();
            this.AdatbazistFrissit2 = new System.Workflow.Activities.CodeActivity();
            this.NincsElégTermékaKözpontiRaktárban = new System.Workflow.Activities.CallExternalMethodActivity();
            this.UpdateHistory3 = new System.Workflow.Activities.CodeActivity();
            this.RendelésTeljesítveKözpontiraktárból = new System.Workflow.Activities.CallExternalMethodActivity();
            this.KiszolgálásKözpontból = new System.Workflow.Activities.SequenceActivity();
            this.HaNemRendelhető = new System.Workflow.Activities.IfElseBranchActivity();
            this.HaRendelhető = new System.Workflow.Activities.IfElseBranchActivity();
            this.UptadteHistory1 = new System.Workflow.Activities.CodeActivity();
            this.delay1s = new System.Workflow.Activities.DelayActivity();
            this.AdatbazistFrissit1 = new System.Workflow.Activities.CodeActivity();
            this.RendelesEllenorzes = new System.Workflow.Activities.IfElseActivity();
            this.RendelniKellKözpontból = new System.Workflow.Activities.CallExternalMethodActivity();
            this.RendelésTeljesítveKészletről = new System.Workflow.Activities.CallExternalMethodActivity();
            this.KiszolgálásKészletről = new System.Workflow.Activities.SequenceActivity();
            this.HaNincsElégKészleten = new System.Workflow.Activities.IfElseBranchActivity();
            this.HaVanElégKészleten = new System.Workflow.Activities.IfElseBranchActivity();
            this.RendelésBejegyez = new System.Workflow.Activities.CodeActivity();
            this.KészletEllenőrzes = new System.Workflow.Activities.IfElseActivity();
            this.Feldolgozásalatt = new System.Workflow.Activities.CallExternalMethodActivity();
            this.KeszletInicializal = new System.Workflow.Activities.CodeActivity();
            this.RendelésBeérkezett = new System.Workflow.Activities.CallExternalMethodActivity();
            // 
            // UpdateHistory2
            // 
            this.UpdateHistory2.Name = "UpdateHistory2";
            this.UpdateHistory2.ExecuteCode += new System.EventHandler(this.UpdateHistory_ExecuteCode);
            // 
            // delay3s
            // 
            this.delay3s.Name = "delay3s";
            this.delay3s.TimeoutDuration = System.TimeSpan.Parse("00:00:03");
            // 
            // AdatbazistFrissit2
            // 
            this.AdatbazistFrissit2.Name = "AdatbazistFrissit2";
            this.AdatbazistFrissit2.ExecuteCode += new System.EventHandler(this.AdatBazistFrissit2_ExecuteCode);
            // 
            // NincsElégTermékaKözpontiRaktárban
            // 
            this.NincsElégTermékaKözpontiRaktárban.InterfaceType = typeof(OPWorkflow.IOrderingService);
            this.NincsElégTermékaKözpontiRaktárban.MethodName = "WorkflowToHost";
            this.NincsElégTermékaKözpontiRaktárban.Name = "NincsElégTermékaKözpontiRaktárban";
            workflowparameterbinding1.ParameterName = "message";
            workflowparameterbinding1.Value = "Nincs elég termék a központi raktárban";
            this.NincsElégTermékaKözpontiRaktárban.ParameterBindings.Add(workflowparameterbinding1);
            // 
            // UpdateHistory3
            // 
            this.UpdateHistory3.Name = "UpdateHistory3";
            this.UpdateHistory3.ExecuteCode += new System.EventHandler(this.UpdateHistory_ExecuteCode);
            // 
            // RendelésTeljesítveKözpontiraktárból
            // 
            this.RendelésTeljesítveKözpontiraktárból.InterfaceType = typeof(OPWorkflow.IOrderingService);
            this.RendelésTeljesítveKözpontiraktárból.MethodName = "WorkflowToHost";
            this.RendelésTeljesítveKözpontiraktárból.Name = "RendelésTeljesítveKözpontiraktárból";
            workflowparameterbinding2.ParameterName = "message";
            workflowparameterbinding2.Value = "Rendelés teljesítve központi raktárból";
            this.RendelésTeljesítveKözpontiraktárból.ParameterBindings.Add(workflowparameterbinding2);
            // 
            // KiszolgálásKözpontból
            // 
            this.KiszolgálásKözpontból.Activities.Add(this.AdatbazistFrissit2);
            this.KiszolgálásKözpontból.Activities.Add(this.delay3s);
            this.KiszolgálásKözpontból.Activities.Add(this.UpdateHistory2);
            this.KiszolgálásKözpontból.Name = "KiszolgálásKözpontból";
            // 
            // HaNemRendelhető
            // 
            this.HaNemRendelhető.Activities.Add(this.UpdateHistory3);
            this.HaNemRendelhető.Activities.Add(this.NincsElégTermékaKözpontiRaktárban);
            this.HaNemRendelhető.Name = "HaNemRendelhető";
            // 
            // HaRendelhető
            // 
            this.HaRendelhető.Activities.Add(this.KiszolgálásKözpontból);
            this.HaRendelhető.Activities.Add(this.RendelésTeljesítveKözpontiraktárból);
            ruleconditionreference1.ConditionName = "VanElegFeltolteni";
            this.HaRendelhető.Condition = ruleconditionreference1;
            this.HaRendelhető.Description = "true";
            this.HaRendelhető.Name = "HaRendelhető";
            // 
            // UptadteHistory1
            // 
            this.UptadteHistory1.Name = "UptadteHistory1";
            this.UptadteHistory1.ExecuteCode += new System.EventHandler(this.UpdateHistory_ExecuteCode);
            // 
            // delay1s
            // 
            this.delay1s.Name = "delay1s";
            this.delay1s.TimeoutDuration = System.TimeSpan.Parse("00:00:01");
            // 
            // AdatbazistFrissit1
            // 
            this.AdatbazistFrissit1.Name = "AdatbazistFrissit1";
            this.AdatbazistFrissit1.ExecuteCode += new System.EventHandler(this.AdatBazistFrissit1_ExecuteCode);
            // 
            // RendelesEllenorzes
            // 
            this.RendelesEllenorzes.Activities.Add(this.HaRendelhető);
            this.RendelesEllenorzes.Activities.Add(this.HaNemRendelhető);
            this.RendelesEllenorzes.Name = "RendelesEllenorzes";
            // 
            // RendelniKellKözpontból
            // 
            this.RendelniKellKözpontból.InterfaceType = typeof(OPWorkflow.IOrderingService);
            this.RendelniKellKözpontból.MethodName = "WorkflowToHost";
            this.RendelniKellKözpontból.Name = "RendelniKellKözpontból";
            workflowparameterbinding3.ParameterName = "message";
            workflowparameterbinding3.Value = "Nincs elég termék készleten, rendelni kell...";
            this.RendelniKellKözpontból.ParameterBindings.Add(workflowparameterbinding3);
            // 
            // RendelésTeljesítveKészletről
            // 
            this.RendelésTeljesítveKészletről.InterfaceType = typeof(OPWorkflow.IOrderingService);
            this.RendelésTeljesítveKészletről.MethodName = "WorkflowToHost";
            this.RendelésTeljesítveKészletről.Name = "RendelésTeljesítveKészletről";
            workflowparameterbinding4.ParameterName = "message";
            workflowparameterbinding4.Value = "Rendelés teljesítve készletről";
            this.RendelésTeljesítveKészletről.ParameterBindings.Add(workflowparameterbinding4);
            // 
            // KiszolgálásKészletről
            // 
            this.KiszolgálásKészletről.Activities.Add(this.AdatbazistFrissit1);
            this.KiszolgálásKészletről.Activities.Add(this.delay1s);
            this.KiszolgálásKészletről.Activities.Add(this.UptadteHistory1);
            this.KiszolgálásKészletről.Name = "KiszolgálásKészletről";
            // 
            // HaNincsElégKészleten
            // 
            this.HaNincsElégKészleten.Activities.Add(this.RendelniKellKözpontból);
            this.HaNincsElégKészleten.Activities.Add(this.RendelesEllenorzes);
            this.HaNincsElégKészleten.Name = "HaNincsElégKészleten";
            // 
            // HaVanElégKészleten
            // 
            this.HaVanElégKészleten.Activities.Add(this.KiszolgálásKészletről);
            this.HaVanElégKészleten.Activities.Add(this.RendelésTeljesítveKészletről);
            ruleconditionreference2.ConditionName = "VanElegRaktaron";
            this.HaVanElégKészleten.Condition = ruleconditionreference2;
            this.HaVanElégKészleten.Name = "HaVanElégKészleten";
            // 
            // RendelésBejegyez
            // 
            this.RendelésBejegyez.Name = "RendelésBejegyez";
            this.RendelésBejegyez.ExecuteCode += new System.EventHandler(this.RendelestBejegyez_ExecuteCode);
            // 
            // KészletEllenőrzes
            // 
            this.KészletEllenőrzes.Activities.Add(this.HaVanElégKészleten);
            this.KészletEllenőrzes.Activities.Add(this.HaNincsElégKészleten);
            this.KészletEllenőrzes.Name = "KészletEllenőrzes";
            // 
            // Feldolgozásalatt
            // 
            this.Feldolgozásalatt.InterfaceType = typeof(OPWorkflow.IOrderingService);
            this.Feldolgozásalatt.MethodName = "WorkflowToHost";
            this.Feldolgozásalatt.Name = "Feldolgozásalatt";
            workflowparameterbinding5.ParameterName = "message";
            workflowparameterbinding5.Value = "Feldolgozás alatt...";
            this.Feldolgozásalatt.ParameterBindings.Add(workflowparameterbinding5);
            // 
            // KeszletInicializal
            // 
            this.KeszletInicializal.Name = "KeszletInicializal";
            this.KeszletInicializal.ExecuteCode += new System.EventHandler(this.KeszletInicializal_ExecuteCode);
            // 
            // RendelésBeérkezett
            // 
            this.RendelésBeérkezett.InterfaceType = typeof(OPWorkflow.IOrderingService);
            this.RendelésBeérkezett.MethodName = "WorkflowToHost";
            this.RendelésBeérkezett.Name = "RendelésBeérkezett";
            workflowparameterbinding6.ParameterName = "message";
            workflowparameterbinding6.Value = "Rendelés beérkezett";
            this.RendelésBeérkezett.ParameterBindings.Add(workflowparameterbinding6);
            // 
            // OrderProcessingWorkflow
            // 
            this.Activities.Add(this.RendelésBeérkezett);
            this.Activities.Add(this.KeszletInicializal);
            this.Activities.Add(this.Feldolgozásalatt);
            this.Activities.Add(this.KészletEllenőrzes);
            this.Activities.Add(this.RendelésBejegyez);
            this.Name = "OrderProcessingWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private DelayActivity delay3s;

        private SequenceActivity KiszolgálásKözpontból;

        private DelayActivity delay1s;

        private SequenceActivity KiszolgálásKészletről;

        private CodeActivity UpdateHistory2;

        private CodeActivity UptadteHistory1;

        private CodeActivity UpdateHistory3;

        private CodeActivity RendelésBejegyez;

        private CallExternalMethodActivity NincsElégTermékaKözpontiRaktárban;

        private CodeActivity AdatbazistFrissit2;

        private CallExternalMethodActivity RendelésTeljesítveKözpontiraktárból;

        private CallExternalMethodActivity RendelniKellKözpontból;

        private IfElseBranchActivity HaNemRendelhető;

        private IfElseBranchActivity HaRendelhető;

        private IfElseActivity RendelesEllenorzes;

        private CallExternalMethodActivity RendelésTeljesítveKészletről;

        private CallExternalMethodActivity RendelésBeérkezett;

        private CallExternalMethodActivity Feldolgozásalatt;

        private CodeActivity AdatbazistFrissit1;

        private CodeActivity KeszletInicializal;

        private IfElseBranchActivity HaNincsElégKészleten;

        private IfElseBranchActivity HaVanElégKészleten;

        private IfElseActivity KészletEllenőrzes;



































































    }
}
