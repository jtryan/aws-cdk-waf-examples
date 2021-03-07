using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AwsDev
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new AwsDevStack(app, "AwsDevStack");
            app.Synth();
        }
    }
}
