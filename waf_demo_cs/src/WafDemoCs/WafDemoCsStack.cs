using Amazon.CDK;
using Amazon.CDK.AWS.WAFv2;

namespace WafDemoCs
{
    public class WafDemoCsStack : Stack
    {
        internal WafDemoCsStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var webAcl = new CfnWebACL(this, "WebAcl", new CfnWebACLProps
            {
                DefaultAction = new CfnWebACL.DefaultActionProperty
                {
                    Allow = new Dictionary<string,object>()
                },
                VisibilityConfig = new CfnWebACL.VisibilityConfigProperty
                {
                    CloudWatchMetricsEnabled = true,
                    SampledRequestsEnabled = true,
                    MetricName = "cs-waf-metric",
                },
                Scope = "REGIONAL",
                Name = "csharp-webAcl",
                Rules = new object[]
                {
                    new CfnWebACL.RuleProperty
                    {
                        Name = "AWS-AWSManagedRulesCommonRuleSet",
                        Priority = 0,
                        Statement = new CfnWebACL.StatementOneProperty
                        {
                            ManagedRuleGroupStatement = new CfnWebACL.ManagedRuleGroupStatementProperty
                            {
                                VendorName = "AWS",
                                Name = "AWSManagedRulesCommonRuleSet",
                            },
                        },
                        VisibilityConfig = new CfnWebACL.VisibilityConfigProperty
                        {
                                CloudWatchMetricsEnabled = true,
                                SampledRequestsEnabled = true,
                                MetricName = "AWS-CS-AWSManagedRulesCommonRuleSet",
                        },
                        OverrideAction = new CfnWebACL.OverrideActionProperty
                        {
                            Count = new Dictionary<string,object>()
                        }, 
                    },
                    new CfnWebACL.RuleProperty
                    {
                        Name = "AWSManagedRulesAnonymousIpList",
                        Priority = 1,
                        Statement = new CfnWebACL.StatementOneProperty
                        {
                            ManagedRuleGroupStatement = new CfnWebACL.ManagedRuleGroupStatementProperty
                            {
                                VendorName = "AWS",
                                Name = "AWSManagedRulesAnonymousIpList",
                            },
                        },
                        VisibilityConfig = new CfnWebACL.VisibilityConfigProperty
                        {
                                CloudWatchMetricsEnabled = true,
                                SampledRequestsEnabled = true,
                                MetricName = "AWS-CS-AWSManagedRulesAnonymousIpList",
                        },
                        OverrideAction = new CfnWebACL.OverrideActionProperty
                        {
                            None = new CfnWebACL.RuleActionProperty{ Count = false },
                        }, 
                    },
                }
            });
        }
    }
}
