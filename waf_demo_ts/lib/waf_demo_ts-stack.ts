import { CfnWebACL } from '@aws-cdk/aws-wafv2';
import * as cdk from '@aws-cdk/core';


export class WafDemoTsStack extends cdk.Stack {
  constructor(scope: cdk.Construct, id: string, props?: cdk.StackProps) {
    super(scope, id, props);

    const webAcl = new CfnWebACL(this, 'WebAcl', {
      defaultAction: {
        allow: {}
      },
      scope: 'REGIONAL',
      visibilityConfig: {
          cloudWatchMetricsEnabled: true,
          sampledRequestsEnabled: true,
          metricName: "ts-waf-metric",
      },
      name: 'ts-webacl',
      rules: [
          {
              name: 'AWS-AWSManagedRulesCommonRuleSet',
              priority: 0,
              statement: {
                  managedRuleGroupStatement: {
                      vendorName: 'AWS',
                      name: 'AWSManagedRulesCommonRuleSet'
                  }
              },
              overrideAction: {
                  none: {},
              },
              visibilityConfig: {
                  sampledRequestsEnabled: true,
                  cloudWatchMetricsEnabled: true,
                  metricName: "AWS-AWSManagedRulesCommonRuleSet"
              }
          },
          {
              name: 'AWS-AWSManagedRulesAmazonIpReputationList',
              priority: 1,
              statement: {
                  managedRuleGroupStatement: {
                      vendorName: 'AWS',
                      name: 'AWSManagedRulesAmazonIpReputationList'
                  }
              },
              overrideAction: {
                  count: {}
              },
              visibilityConfig: {
                  sampledRequestsEnabled: true,
                  cloudWatchMetricsEnabled: true,
                  metricName: "AWS-AWSManagedRulesAmazonIpReputationList"
              }
          }
        ],
      
    });
  }
}
