#!/usr/bin/env node
import 'source-map-support/register';
import * as cdk from '@aws-cdk/core';
import { WafDemoTsStack } from '../lib/waf_demo_ts-stack';

const app = new cdk.App();
new WafDemoTsStack(app, 'WafDemoTsStack');
