from aws_cdk import (
    core,
    aws_wafv2 as wafv2

)

class AwsDevPyStack(core.Stack):

    def __init__(self, scope: core.Construct, construct_id: str, **kwargs) -> None:
        super().__init__(scope, construct_id, **kwargs)

        web_acl = wafv2.CfnWebACL(
            scope_=self, id='WebAcl',
            default_action=wafv2.CfnWebACL.DefaultActionProperty(allow={}),
            scope='REGIONAL',
            visibility_config=wafv2.CfnWebACL.VisibilityConfigProperty(
                cloud_watch_metrics_enabled=True,
                sampled_requests_enabled=True,
                metric_name='testwafmetric',
            ),
            name='test-web-acl',
            rules=[
                {
                    'name': 'AWS-AWSManagedRulesCommonRuleSet',
                    'priority': 0,
                    'statement': {
                        'managedRuleGroupStatement': {
                            'vendorName': 'AWS',
                            'name': 'AWSManagedRulesCommonRuleSet'
                        }
                    },
                    'overrideAction': {
                        'none': {}
                    },
                    'visibilityConfig': {
                        'sampledRequestsEnabled': True,
                        'cloudWatchMetricsEnabled': True,
                        'metricName': "AWS-AWSManagedRulesCommonRuleSet"
                    }
                },
                {
                    'name': 'AWS-AWSManagedRulesAmazonIpReputationList',
                    'priority': 1,
                    'statement': {
                        'managedRuleGroupStatement': {
                            'vendorName': 'AWS',
                            'name': 'AWSManagedRulesAmazonIpReputationList'
                        }
                    },
                    'overrideAction': {
                        'count': {}
                    },
                    'visibilityConfig': {
                        'sampledRequestsEnabled': True,
                        'cloudWatchMetricsEnabled': True,
                        'metricName': "AWS-AWSManagedRulesAmazonIpReputationList"
                    }
                }

            ]
        )
