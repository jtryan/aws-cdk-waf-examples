using Amazon.CDK;
using Amazon.CDK.AWS.WAFv2;

using System.Collections.Generic;


namespace AwsDev
{
    public class AwsDevStack : Stack
    {
        internal AwsDevStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {

            var _ = new CfnWebACL(this, "WebAcl", new CfnWebACLProps
            {
                DefaultAction = new CfnWebACL.DefaultActionProperty
                {
                    Allow = new CfnWebACL.RuleActionProperty { Allow = true }
                },
                VisibilityConfig = new CfnWebACL.VisibilityConfigProperty
                {
                    CloudWatchMetricsEnabled = true,
                    SampledRequestsEnabled = true,
                    MetricName = "test-waf-metric",
                },
                Scope = "REGIONAL",
                Name ="csharp-webAcl",
                Rules = new object[]
                {
                    new CfnWebACL.RuleProperty
                    {
                        Name = "AWS-AWSManagedRulesCommonRuleSet",
                        Priority = 0,
                        Statement = {},
                        // Statement = new CfnWebACL.ManagedRuleGroupStatementProperty
                        // {
                        //     VendorName = "AWS",
                        //     Name = "AWSManagedRulesCommonRuleSet",
                        //     },
                        VisibilityConfig = new CfnWebACL.VisibilityConfigProperty
                        {
                                CloudWatchMetricsEnabled = true,
                                SampledRequestsEnabled = true,
                                MetricName = "AWS AWSManagedRulesCommonRuleSet",
                        },
                        OverrideAction = new CfnWebACL.OverrideActionProperty { None = {}},
                    },
                      
                }
            
            });
        }
    }
}

