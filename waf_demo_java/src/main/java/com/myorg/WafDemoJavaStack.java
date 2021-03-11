package com.myorg;


import org.jetbrains.annotations.NotNull;
import software.amazon.awscdk.core.Construct;
import software.amazon.awscdk.core.Stack;
import software.amazon.awscdk.core.StackProps;
import software.amazon.awscdk.services.wafv2.CfnWebACL;

import java.util.ArrayList;

public class WafDemoJavaStack extends Stack {
    public WafDemoJavaStack(final Construct scope, final String id) {
        this(scope, id, null);
    }

    public WafDemoJavaStack(final Construct scope, final String id, final StackProps props) {
        super(scope, id, props);

        CfnWebACL.VisibilityConfigProperty visibilityConfigProperty = new CfnWebACL.VisibilityConfigProperty() {
            @Override
            public @NotNull Object getCloudWatchMetricsEnabled() {
                return true;
            }

            @Override
            public @NotNull String getMetricName() {
                return "java-waf-metric";
            }

            @Override
            public @NotNull Object getSampledRequestsEnabled() {
                return true;
            }
        };

        //TODO: fix this
//        CfnWebACL.DefaultActionProperty defaultActionProperty = CfnWebACL.DefaultActionProperty.builder()
//                .allow(CfnWebACL.RuleActionProperty.builder().allow(true).build())
//                .build();
//        };

        final CfnWebACL cfnWebACL =
            CfnWebACL.Builder.create(this, "webAcl")
                    .name("java-WebAcl")
                    .scope("REGIONAL")
                    .defaultAction(CfnWebACL.DefaultActionProperty.builder()
                            .allow(CfnWebACL.RuleActionProperty.builder().allow(true).build())
                            .build())
                    .visibilityConfig(visibilityConfigProperty)
                    .rules(new ArrayList<>()) 
                    //TODO: add rules
                    .build();

    }
            
}
