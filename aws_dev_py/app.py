#!/usr/bin/env python3

from aws_cdk import core

from aws_dev_py.aws_dev_py_stack import AwsDevPyStack


app = core.App()
AwsDevPyStack(app, "aws-dev-py")

app.synth()
