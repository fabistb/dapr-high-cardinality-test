# dapr-high-cardinality-test
Sample repository to test the high cardinality functionality from dapr described here:
https://docs.dapr.io/operations/monitoring/metrics/metrics-overview/#high-cardinality-metrics

# Dapr Version
Depending on the Dapr version the behavior regarding the high cardinality and the required configuration can change.
To identify the current dapr version run the following command.

```bash
dapr --version
```

# Pre Dapr 1.13.x
Pre Dapr 1.13.x each route had to be configured via a Regex.
For a version > 1.13.x replace the `configuration.yaml` accordingly.

## Sender

```yaml
apiVersion: dapr.io/v1alpha1
kind: Configuration
metadata:
  name: daprConfig
  namespace: default
spec:
  tracing:
    samplingRate: "1"
    zipkin:
      endpointAddress: "http://localhost:9411/api/v2/spans"
  metric:
    enabled: true
    rules:
    - name: dapr_runtime_service_invocation_req_sent_total
      labels:
        - name: method
          regex:
            "api/Receive/": "api/Receive/.+"
    - name: dapr_runtime_service_invocation_res_recv_total
      labels:
        - name: method
          regex:
            "api/Receive/": "api/Receive/.+"
    - name: dapr_runtime_service_invocation_res_recv_latency_ms
      labels:
        - name: method
          regex:
            "api/Receive/": "api/Receive/.+"
    - name: dapr_http_server_response_count
      labels:
        - name: path
          regex:
            "/v1.0/invoke/receiver/method/api/Receive/": "/v1.0/invoke/receiver/method/api/Receive/.+"
    - name: dapr_http_server_request_count
      labels:
        - name: path
          regex:
            "/v1.0/invoke/receiver/method/api/Receive/": "/v1.0/invoke/receiver/method/api/Receive/.+"
    - name: dapr_http_server_latency
      labels:
        - name: path
          regex:
            "/v1.0/invoke/receiver/method/api/Receive/": "/v1.0/invoke/receiver/method/api/Receive/.+"
    - name: dapr_http_server_latency_count
      labels:
        - name: path
          regex:
            "/v1.0/invoke/receiver/method/api/Receive/": "/v1.0/invoke/receiver/method/api/Receive/.+"
    - name: dapr_http_server_latency_sum
      labels:
        - name: path
          regex:
            "/v1.0/invoke/receiver/method/api/Receive/": "/v1.0/invoke/receiver/method/api/Receive/.+"
```

## Receiver
```yaml
apiVersion: dapr.io/v1alpha1
kind: Configuration
metadata:
  name: daprConfig
  namespace: default
spec:
  tracing:
    samplingRate: "1"
    zipkin:
      endpointAddress: "http://localhost:9411/api/v2/spans"
  metric:
    enabled: true
    rules:
    - name: dapr_runtime_service_invocation_req_recv_total
      labels:
      - name: method
        regex:
          "api/Receive/": "api/Receive/.+"
    - name: dapr_runtime_service_invocation_res_sent_total
      labels:
      - name: method
        regex:
          "api/Receive/": "api/Receive/.+"
    - name: dapr_http_client_roundtrip_latency
      labels:
      - name: path
        regex:
          "api/Receive/": "api/Receive/.+"
    - name: dapr_http_client_completed_count
      labels:
        - name: path
          regex:
            "api/Receive/": "api/Receive/.+"
    - name: dapr_http_client_sent_bytes_sum
      labels:
        - name: path
          regex:
            "api/Receive/": "api/Receive/.+"
    - name: dapr_http_client_sent_bytes
      labels:
        - name: path
          regex:
            "api/Receive/": "api/Receive/.+"
    - name: dapr_runtime_acl_global_policy_action_allowed_total
      labels:
        - name: operation
          regex:
            "api/Receive/": "api/Receive/.+"
```

# Dapr 1.13.x
With Dapr 1.13.x a new configuration has been  `spec.metric.http.increasedCardinality`.
Setting the value to `false` will automatically filter out all high cardinality metrics.