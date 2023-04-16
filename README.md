
# Log4net.Appenders.Fluentd
This is Fork of Fluentd appender for Log4net.

## Fork changes
   - Fixed unable using properties as metrics data. LoggingEvent loggingEvent in Append doesn't contain properties by default.
   - PropertiesFilterRegex parameter. You can configure which parameters by name will appear in metrix of fluentd
   - Minor: Demo app run in net 6.0
   - Using thread to send log

## Installation

    PM> Install-Package Log4net.Appenders.Fluentd
    or
    > dotnet add package Log4net.Appenders.Fluentd

##  Configuration

```xml
<appender name="Fluentd" type="Log4net.Appenders.Fluentd.FluentdAppender, Log4net.Appenders.Fluentd">
    <Host>127.0.0.1</Host>
    <Port>24224</Port>
    <Tag>YourTagHere</Tag>
    <NoDelay>false</NoDelay>
    <ReceiveBufferSize>8192</ReceiveBufferSize>
    <SendBufferSize>8192</SendBufferSize>
    <SendTimeout>1000</SendTimeout>
    <ReceiveTimeout>1000</ReceiveTimeout>
    <LingerEnabled>true</LingerEnabled>
    <LingerTime>1000</LingerTime>
    <EmitStackTraceWhenAvailable>true</EmitStackTraceWhenAvailable>
    <IncludeAllProperties>false</IncludeAllProperties>
    <PropertiesFilterRegex>^metric</PropertiesFilterRegex> <!-- works ony if IncludeAllProperties is true -->
    <layout type="log4net.Layout.PatternLayout">
      <conversionPattern value="%date{yyyy-MM-dd HH:mm:ss.fff} [%thread] [%property{Context}] %-5level %logger - %message%newline" />
    </layout>
</appender>
```
  

### Dependencies

    - log4net
    - MsgPack.Cli

### Building the project

    dotnet build

## Contribute

If you have any idea for an improvement or found a bug, do not hesitate to open an issue.


## License

Log4net.Appenders.Fluentd is distributed under MIT License.

##  PropertiesFilterRegex behavior

```
    <IncludeAllProperties>false</IncludeAllProperties>
    <PropertiesFilterRegex>^metric</PropertiesFilterRegex> <!-- works ony if IncludeAllProperties is true -->
```
```
2023-04-16T16:57:29+00:00	YourTagHere	{"level":"ERROR","message":"2023-04-16 19:57:29.404 [1] [(null)] ERROR DemoApp.Program - Error Message\r\nSystem.Exception: This is Exception\r\n","logger_name":"DemoApp.Program"}
```
```
    <IncludeAllProperties>true</IncludeAllProperties>
    <PropertiesFilterRegex>^metric</PropertiesFilterRegex> <!-- works ony if IncludeAllProperties is true -->
```
```
2023-04-16T16:58:41+00:00	YourTagHere	{"level":"ERROR","message":"2023-04-16 19:58:41.630 [1] [(null)] ERROR DemoApp.Program - Error Message\r\nSystem.Exception: This is Exception\r\n","logger_name":"DemoApp.Program","metric_down_count":1,"metric_managed_thread_id":1}
```
```
    <IncludeAllProperties>true</IncludeAllProperties>
    <PropertiesFilterRegex></PropertiesFilterRegex> <!-- works ony if IncludeAllProperties is true -->
```
```
2023-04-16T16:59:44+00:00	YourTagHere	{"level":"ERROR","message":"2023-04-16 19:59:44.170 [1] [(null)] ERROR DemoApp.Program - Error Message\r\nSystem.Exception: This is Exception\r\n","logger_name":"DemoApp.Program","log4net:HostName":"OVERZOO","log4net:Identity":"","log4net:UserName":"OVERZOO\\overzoo","animal":"Zebra","metric_down_count":1}
```
