package com.myorg;

import software.amazon.awscdk.core.App;

import java.util.Arrays;

public class WafDemoJavaApp {
    public static void main(final String[] args) {
        App app = new App();

        new WafDemoJavaStack(app, "WafDemoJavaStack");

        app.synth();
    }
}
