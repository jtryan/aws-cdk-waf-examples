package com.myorg;

import software.amazon.awscdk.core.Construct;
import software.amazon.awscdk.core.Stack;
import software.amazon.awscdk.core.StackProps;
import software.amazon.awscdk.services.wafv2.CfnWebACL;
import software.amazon.awscdk.services.wafv2.CfnWebACLProps;

public class WafDemoJavaStack extends Stack {
    public WafDemoJavaStack(final Construct scope, final String id) {
        this(scope, id, null);
    }

    public WafDemoJavaStack(final Construct scope, final String id, final StackProps props) {
        super(scope, id, props);

        CfnWebACL.Builder.create(this, "webAcl")
                .name("java-WebAcl")
                .scope("REGIONAL")
                .defaultAction(CfnWebACL.DefaultActionProperty.builder()
                        .allow(CfnWebACL.RuleActionProperty.builder().allow(true).build())
                        .build())
                .visibilityConfig(CfnWebACL.VisibilityConfigProperty.builder()
                        .cloudWatchMetricsEnabled(true)
                        .sampledRequestsEnabled(true)
                        .metricName("java-waf-metric")
                        .build())
                .build();

    }
            
}
