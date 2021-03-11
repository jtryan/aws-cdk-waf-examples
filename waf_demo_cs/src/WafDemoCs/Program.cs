using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WafDemoCs
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new WafDemoCsStack(app, "WafDemoCsStack");
            app.Synth();
        }
    }
}
