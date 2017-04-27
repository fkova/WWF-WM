using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Windows.Forms;

namespace WF4
{

    public sealed class UpdateHistory : CodeActivity
    {
        public InArgument<int> RendeltMennyiség { get; set; }
        public InArgument<int> Készleten { get; set; }
        public InArgument<int> KözpontiRaktárban { get; set; }
        public OutArgument<string> History { get; set; }
        public OutArgument<string> Result { get; set; }
        public InArgument<double> Timer { get; set; }
        
        protected override void Execute(CodeActivityContext context)
        {
            double x = (DateTime.Now.Minute * 60000 + DateTime.Now.Second * 1000
                    + DateTime.Now.Millisecond - Timer.Get(context)) / 1000;

            context.SetValue(Result,"\r\nTermékkiszolgálás sikeres");

            if (RendeltMennyiség.Get(context) <= Készleten.Get(context))
            {
                 context.SetValue(History, x.ToString() + " s készletről");
            }
            else if (Készleten.Get(context) + KözpontiRaktárban.Get(context) >= RendeltMennyiség.Get(context))
            {
                context.SetValue(History, x.ToString() + " s központból");
            }
            else
            {
                context.SetValue(History, "Készlethiány");
                context.SetValue(Result, "\r\nMaximum " + (Készleten.Get(context) + KözpontiRaktárban.Get(context)) + " db rendelhető!");
            }
        }
    }
}
