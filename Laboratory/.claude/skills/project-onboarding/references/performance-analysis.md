\# Performance Analysis Reference



\## 1. Purpose and Scope



This reference defines a systematic, technology-independent methodology for analyzing software performance in existing repositories.



The objective is to identify performance bottlenecks, inefficient resource usage, expensive operations, scalability limitations, and architectural decisions that may negatively affect application responsiveness and throughput.



This reference applies to:



\- .NET applications

\- Java applications

\- Spring Framework and Spring Boot

\- ASP.NET Core

\- Web applications

\- REST APIs

\- Desktop applications

\- Background workers

\- Scheduled jobs

\- Database-driven applications

\- Microservices

\- Distributed systems

\- Cloud and on-premises deployments



The analysis must be evidence-based and read-only.



Technology-specific performance details should be investigated using the actual frameworks and libraries found in the repository.



Related references:



\- `dotnet-analysis.md`

\- `java-analysis.md`

\- `sqlserver-analysis.md`

\- `oracle-analysis.md`

\- `architecture-analysis.md`

\- `api-analysis.md`



Do not duplicate their detailed responsibilities. Focus on performance characteristics and cross-component bottlenecks.



\---



\## 2. Performance Analysis Principles



Follow these principles:



1\. Never claim that an application is slow based only on code appearance.

2\. Distinguish potential performance risks from measured bottlenecks.

3\. Identify the actual execution path before recommending optimization.

4\. Evaluate performance in the context of expected workload and business requirements.

5\. Consider CPU, memory, database, network, disk I/O, and external dependencies.

6\. Do not optimize code without understanding its behavior and correctness requirements.

7\. Avoid premature optimization.

8\. Do not recommend caching without understanding data consistency and invalidation requirements.

9\. Do not assume asynchronous code is automatically faster.

10\. Do not assume adding threads or parallel execution improves throughput.

11\. Consider resource consumption under concurrent workloads.

12\. Preserve existing business behavior when proposing optimizations.

13\. Report missing runtime measurements explicitly.

14\. Do not invent response times, throughput figures, or resource utilization values.



\### Evidence Classification



Use these labels:



\- Verified: directly confirmed by source code, configuration, or available measurements.

\- Inferred: supported by code structure but not confirmed through runtime measurement.

\- Requires Runtime Measurement: needs profiling, metrics, or benchmarking.

\- Requires Developer Confirmation: depends on expected workload or business requirements.

\- Not Available: required evidence is unavailable.



\### Confidence Levels



\- High

\- Medium

\- Low



\### Performance Finding Categories



Distinguish:



\- Static Code Risk

\- Database Query Risk

\- Memory Risk

\- CPU Risk

\- I/O Risk

\- Network Risk

\- Concurrency Risk

\- Scalability Risk

\- Measured Runtime Bottleneck



A static code risk must not be presented as a measured runtime bottleneck.



\---



\## 3. Application Performance Overview



Identify the application's major execution paths.



Inspect:



\- Application entry points

\- HTTP endpoints

\- Controllers

\- Application services

\- Background workers

\- Scheduled jobs

\- Database operations

\- External API calls

\- File operations

\- Messaging consumers

\- Long-running processes



Determine:



1\. Which operations are likely to be performance-sensitive?

2\. Which operations are frequently executed?

3\. Which operations process large amounts of data?

4\. Which operations depend on external services?

5\. Which operations execute synchronously?

6\. Which operations run in the background?

7\. Which operations may become bottlenecks under concurrency?



Do not infer actual request frequency without metrics or developer confirmation.



\### Expected Output



Provide a list of important execution paths with:



\- Operation name

\- Entry point

\- Main components

\- Resource dependencies

\- Potential performance risks

\- Evidence

\- Measurement requirements



\---



\## 4. CPU Utilization and Processing Efficiency



Analyze CPU-intensive operations.



Inspect:



\- Nested loops

\- Repeated calculations

\- Expensive algorithms

\- Unnecessary object transformations

\- Large serialization operations

\- Complex regular expressions

\- Repeated parsing

\- Excessive reflection

\- Repeated collection searches

\- Unnecessary sorting

\- Recursive operations



Evaluate algorithmic complexity where possible.



Look for:



\- O(n²) operations over potentially large collections

\- Repeated linear searches

\- Unnecessary sorting

\- Repeated computation of identical results

\- Expensive processing inside loops

\- Inefficient data transformations



For each finding, identify:



\- Operation

\- Input size assumptions

\- Algorithmic complexity, if determinable

\- Potential CPU impact

\- Evidence

\- Recommended investigation



Do not assume an algorithm is problematic without considering actual input sizes and execution frequency.



\---



\## 5. Memory Management and Allocation



Analyze memory usage patterns.



Inspect:



\- Large object allocations

\- Repeated object creation

\- Large collections

\- Unbounded in-memory data

\- Static collections

\- Long-lived references

\- Memory caching

\- Serialization buffers

\- File buffering

\- Object retention

\- Resource disposal



Investigate:



\- Potential memory leaks

\- Excessive allocations

\- Large Object Heap usage in .NET where applicable

\- Garbage Collection pressure

\- Java heap pressure

\- Retained object graphs

\- Unnecessary object duplication

\- Large response construction



Check resource lifecycle management for:



\- Streams

\- Files

\- Database connections

\- HTTP responses

\- Network sockets

\- Timers

\- Background tasks



Do not claim a memory leak without runtime evidence or a clearly demonstrated unbounded retention pattern.



\---



\## 6. Database Performance



Analyze database access patterns.



Inspect:



\- SQL queries

\- ORM queries

\- Repository methods

\- Stored procedures

\- Database functions

\- Query construction

\- Data loading strategies

\- Transaction boundaries

\- Connection management



Investigate:



\### Query Efficiency



\- N+1 query patterns

\- Repeated database calls

\- Unnecessary queries

\- Excessive joins

\- Unbounded result sets

\- Unnecessary columns

\- Missing filtering

\- Inefficient pagination

\- Non-sargable predicates

\- Repeated queries for identical data



\### ORM Behavior



Where applicable, inspect:



\- Lazy loading

\- Eager loading

\- Explicit loading

\- Tracking versus no-tracking queries

\- Entity materialization

\- Change tracking overhead

\- Fetch strategies

\- Persistence context behavior

\- Bulk operations



\### Database Indexing



Inspect available evidence for:



\- Missing index candidates

\- Unused indexes

\- Overlapping indexes

\- Index maintenance overhead

\- Composite index ordering

\- Query predicate compatibility



Do not claim that an index is missing solely because a query filters on a column. Execution plans and workload evidence are needed for a reliable conclusion.



\### Transactions



Investigate:



\- Long-running transactions

\- Excessive transaction scope

\- Unnecessary locks

\- High contention

\- Repeated commits

\- Transaction nesting

\- Blocking risks



Database-specific investigation belongs to:



\- `sqlserver-analysis.md`

\- `oracle-analysis.md`



\---



\## 7. API and Request Performance



Analyze request-processing efficiency.



Inspect:



\- Request pipeline

\- Middleware

\- Controllers

\- Endpoint handlers

\- Serialization

\- Response generation

\- Database calls

\- External API calls



Investigate:



\- Large response payloads

\- Missing pagination

\- Excessive synchronous operations

\- Unnecessary object mapping

\- Repeated validation work

\- Expensive middleware

\- Blocking operations

\- Unnecessary database round trips

\- Unbounded request processing



Evaluate:



\- Request processing stages

\- Potential latency contributors

\- Response size

\- Cancellation propagation

\- Streaming opportunities

\- Request timeout configuration



Do not claim actual API latency without runtime measurements.



Detailed endpoint design belongs to `api-analysis.md`.



\---



\## 8. Asynchronous Processing and Concurrency



Analyze asynchronous execution and concurrent operations.



Inspect:



\- Async/await usage

\- Blocking calls

\- Thread creation

\- Thread pools

\- Task scheduling

\- Synchronization primitives

\- Locks

\- Semaphores

\- Concurrent collections

\- Background queues

\- Parallel processing



Investigate:



\- Sync-over-async

\- Thread pool starvation risks

\- Excessive task creation

\- Unbounded concurrency

\- Unnecessary locking

\- Lock contention

\- Deadlock risks

\- Shared mutable state

\- Incorrect cancellation handling

\- Concurrent access to non-thread-safe resources



Where applicable, distinguish:



\- I/O-bound operations

\- CPU-bound operations

\- Parallel execution

\- Asynchronous execution



Do not recommend converting every method to asynchronous execution.



Do not introduce parallel processing without considering data consistency, resource limits, and ordering requirements.



\---



\## 9. Network and External Service Performance



Analyze network-related bottlenecks.



Inspect:



\- HTTP clients

\- External service integrations

\- RPC calls

\- Messaging

\- Network requests

\- Connection pooling

\- DNS resolution

\- Response handling

\- Payload serialization



Investigate:



\- Excessive sequential external calls

\- Missing connection reuse

\- Large network payloads

\- Unnecessary data transfer

\- Excessive polling

\- Missing timeouts

\- Inefficient retry policies

\- Slow dependency chains

\- Unnecessary network round trips



Where applicable, investigate:



\- HTTP keep-alive

\- Connection pooling

\- HTTP/2

\- gRPC streaming

\- Compression

\- Request batching



Do not execute external requests during static analysis.



\---



\## 10. Caching Architecture



Analyze existing caching mechanisms and potential caching opportunities.



Inspect:



\- In-memory caching

\- Distributed caching

\- HTTP caching

\- Database caching

\- Application-level caching

\- CDN configuration

\- Cache providers

\- Cache key construction

\- Cache expiration

\- Cache invalidation



Determine:



1\. What data is cached?

2\. Which component owns the cache?

3\. How long does cached data remain valid?

4\. How is stale data invalidated?

5\. Is cache data shared across instances?

6\. What happens when the cache is unavailable?

7\. Is cache memory bounded?



Investigate risks:



\- Cache stampede

\- Cache poisoning

\- Stale data

\- Missing invalidation

\- Unbounded cache growth

\- Incorrect cache key design

\- Inconsistent distributed cache behavior



Do not recommend caching sensitive or frequently changing data without considering security and consistency.



Caching recommendations must include:



\- Target data

\- Expected benefit

\- Consistency requirements

\- Invalidation strategy

\- Memory or storage implications

\- Failure behavior



\---



\## 11. File and Storage I/O



Analyze file and storage operations.



Inspect:



\- File reading

\- File writing

\- File uploads

\- File downloads

\- Temporary files

\- File processing

\- Archive extraction

\- Large document processing

\- Image processing

\- Stream usage



Investigate:



\- Full-file buffering

\- Unnecessary copying

\- Synchronous disk I/O

\- Repeated file reads

\- Unbounded temporary storage

\- Large file processing in memory

\- Missing streaming

\- Resource disposal problems



Consider whether streaming or chunked processing is appropriate.



Do not assume streaming is always better for small files.



\---



\## 12. Background Jobs and Scheduled Processing



Analyze background execution.



Inspect:



\- Scheduled tasks

\- Background services

\- Queue consumers

\- Batch jobs

\- Recurring jobs

\- Timers

\- Worker services



Investigate:



\- Excessive polling

\- Large batch sizes

\- Unbounded queues

\- Long-running jobs

\- Duplicate processing

\- Excessive concurrency

\- Missing backpressure

\- Resource contention with request processing

\- Inefficient retry behavior



Determine:



1\. How jobs are triggered.

2\. Whether execution is sequential or parallel.

3\. Whether job concurrency is limited.

4\. Whether failures are retried.

5\. Whether job execution is observable.

6\. Whether large workloads are processed incrementally.



Do not assume a background job is harmless to API performance.



\---



\## 13. Scalability and Capacity Risks



Evaluate whether the architecture can support increased workloads.



Investigate:



\- Statelessness

\- Shared session state

\- Horizontal scaling constraints

\- Shared resource bottlenecks

\- Database connection limits

\- Thread pool limits

\- Memory-intensive components

\- Single-instance background workers

\- Centralized bottlenecks

\- Synchronous dependency chains



Distinguish:



1\. Verified scalability capabilities.

2\. Potential scalability capabilities.

3\. Known scalability constraints.

4\. Unknown deployment characteristics.



Do not claim that a system supports horizontal scaling without considering state, shared resources, and deployment evidence.



\---



\## 14. Reliability and Performance Under Load



Investigate mechanisms that protect the system under heavy load.



Inspect:



\- Timeouts

\- Rate limiting

\- Backpressure

\- Bulkheads

\- Circuit breakers

\- Bounded queues

\- Request limits

\- Connection limits

\- Graceful degradation

\- Load shedding



Identify:



\- Resource exhaustion risks

\- Cascading failures

\- Retry storms

\- Queue growth

\- Dependency overload

\- Unbounded request processing



Detailed resilience analysis belongs to `architecture-analysis.md`.



\---



\## 15. Observability and Performance Measurement



Evaluate whether the system can be measured and diagnosed.



Inspect:



\- Application metrics

\- Request duration metrics

\- Database metrics

\- CPU metrics

\- Memory metrics

\- Garbage Collection metrics

\- Thread pool metrics

\- Queue metrics

\- Distributed tracing

\- Structured logging

\- Profiling integrations

\- Health endpoints



Determine whether the available observability can identify:



\- Slow endpoints

\- Expensive database queries

\- High CPU operations

\- Memory growth

\- Thread contention

\- External dependency latency

\- Queue backlogs



\### Important Performance Metrics



Where available, consider:



\- Average latency

\- Median latency

\- p95 latency

\- p99 latency

\- Requests per second

\- Throughput

\- Error rate

\- CPU utilization

\- Memory utilization

\- Allocation rate

\- Garbage Collection frequency

\- Database query duration

\- Connection pool utilization

\- Queue depth



Do not invent metrics that are not available.



Distinguish source-code observations from measured production or test-environment data.



\---



\## 16. Performance Anti-Patterns



Look for common performance anti-patterns:



\- N+1 Queries

\- Chatty Database Access

\- Unbounded Queries

\- Large Object Materialization

\- Repeated Expensive Computation

\- Blocking I/O

\- Sync-over-Async

\- Excessive Locking

\- Thread Pool Starvation

\- Unbounded Task Creation

\- Excessive Serialization

\- Large API Responses

\- Missing Pagination

\- Unbounded In-Memory Collections

\- Cache Stampede

\- Excessive External Requests

\- Repeated Object Mapping

\- Inefficient Batch Processing

\- Excessive Polling

\- Long-Running Transactions



For each finding, provide:



\- Finding ID

\- Description

\- Evidence

\- Affected component

\- Potential impact

\- Severity

\- Confidence

\- Measurement requirements

\- Recommended investigation



Do not treat every pattern as a defect without considering actual workload.



\---



\## 17. Performance Risk Prioritization



Use the following priority levels:



\### P0 - Critical



A severe performance condition that causes or is strongly evidenced to cause critical system unavailability or essential business-operation failure.



\### P1 - High



A significant bottleneck or resource risk that can materially affect important application operations.



\### P2 - Medium



A performance risk that may affect response times, resource usage, or scalability under specific workloads.



\### P3 - Low



Minor optimization opportunities with limited expected impact.



For every finding, explain:



\- Expected workload

\- Potential impact

\- Evidence

\- Measurement status

\- Priority justification



Do not assign P0 or P1 based only on speculative concerns.



\---



\## 18. Performance Finding Format



For every important finding, use this structure:



\### Finding ID



Example: PERF-001



\### Title



Short and specific description.



\### Category



CPU, Memory, Database, Network, API, Concurrency, I/O, Caching, or Scalability.



\### Priority



P0 / P1 / P2 / P3



\### Confidence



High / Medium / Low



\### Evidence Classification



Verified / Inferred / Requires Runtime Measurement / Requires Developer Confirmation



\### Location



\- File path

\- Class

\- Method

\- Query

\- Configuration key

\- Relevant line numbers, if available



\### Description



Explain the observed behavior.



\### Potential Impact



Explain the possible effect on:



\- Latency

\- Throughput

\- CPU

\- Memory

\- Database load

\- Network utilization

\- Availability



\### Measurement Required



Specify what must be measured to confirm the bottleneck.



\### Recommendation



Provide a practical improvement strategy.



\### Risk of Change



Identify possible effects on:



\- Business behavior

\- Data consistency

\- Concurrency

\- Memory

\- Operational complexity



\---



\## 19. Optimization Recommendation Rules



Recommendations must be evidence-based and prioritized.



Follow these rules:



1\. Prefer fixing a demonstrated bottleneck over general code cleanup.

2\. Do not optimize code solely to reduce line count.

3\. Avoid unnecessary architectural complexity.

4\. Consider database and network costs before micro-optimizing CPU operations.

5\. Evaluate memory and CPU trade-offs.

6\. Consider cache consistency before introducing caching.

7\. Consider concurrency limits before introducing parallelism.

8\. Preserve business behavior.

9\. Recommend measurement before high-risk optimization.

10\. Separate quick improvements from architectural changes.



For every recommendation, explain:



\- Problem being addressed

\- Expected benefit

\- Implementation complexity

\- Potential side effects

\- Required verification



Do not implement optimizations during analysis.



\---



\## 20. Read-Only Analysis Restrictions



This reference authorizes static performance analysis only.



Unless explicitly authorized:



\- Do not modify source code.

\- Do not modify configuration files.

\- Do not change database schemas.

\- Do not create or modify indexes.

\- Do not execute data-changing SQL.

\- Do not run migrations.

\- Do not install profiling or benchmarking tools.

\- Do not execute load tests.

\- Do not run stress tests.

\- Do not access production infrastructure.

\- Do not restart services.

\- Do not change resource limits.

\- Do not change caching configuration.

\- Do not trigger CI/CD pipelines.

\- Do not deploy applications.

\- Do not modify Git branches, commits, or history.



Static inspection of source code and existing configuration is permitted within the available environment and permissions.



If runtime measurements are necessary, explain:



1\. Which operation requires measurement.

2\. Which environment is appropriate.

3\. Which metrics should be collected.

4\. What workload is needed.

5\. What risks the test may introduce.



Request explicit permission before performing runtime or load-related tests.



\---



\## 21. Expected Performance Analysis Report



Produce the final report in Persian.



Preserve technical identifiers, class names, method names, file paths, query names, framework terminology, and metric names in English.



Use this structure:



\# گزارش تحلیل عملکرد پروژه



\## 1. خلاصه وضعیت عملکرد



\- وضعیت کلی

\- مهم‌ترین ریسک‌ها

\- مهم‌ترین نقاط قوت

\- محدودیت‌های بررسی

\- وضعیت وجود داده‌های اندازه‌گیری



\## 2. مسیرهای اصلی پردازش



\- Entry Points

\- Important Operations

\- Background Jobs

\- External Dependencies



\## 3. تحلیل CPU



\- Expensive Operations

\- Algorithmic Complexity

\- Repeated Computations

\- CPU Risks



\## 4. تحلیل حافظه



\- Memory Allocation

\- Object Retention

\- Large Collections

\- Resource Management

\- Memory Risks



\## 5. تحلیل دیتابیس



\- Query Patterns

\- N+1 Risks

\- ORM Behavior

\- Index Candidates

\- Transaction Risks



\## 6. تحلیل API



\- Request Processing

\- Response Size

\- Serialization

\- Pagination

\- Blocking Operations



\## 7. تحلیل Async و Concurrency



\- Async/Await

\- Threading

\- Locking

\- Parallel Processing

\- Thread Pool Risks



\## 8. تحلیل Network و External Services



\- HTTP Clients

\- Connection Reuse

\- External Calls

\- Network Payloads

\- Timeout and Retry



\## 9. تحلیل Caching



\- Existing Cache

\- Cache Opportunities

\- Invalidation

\- Consistency

\- Cache Risks



\## 10. تحلیل File و Storage I/O



\- File Operations

\- Streaming

\- Buffering

\- Storage Risks



\## 11. تحلیل Background Jobs



\- Scheduled Tasks

\- Queues

\- Batch Processing

\- Concurrency

\- Backpressure



\## 12. Scalability و Capacity



\- Horizontal Scaling

\- Shared Resources

\- Bottlenecks

\- Capacity Constraints



\## 13. Observability و Metrics



\- Available Metrics

\- Logging

\- Tracing

\- Profiling

\- Missing Measurements



\## 14. مشکلات و ریسک‌های عملکردی



برای هر مورد:



\- Finding ID

\- شرح

\- شواهد

\- اثر احتمالی

\- شدت

\- میزان اطمینان

\- نیاز اندازه‌گیری

\- پیشنهاد بهبود



\## 15. اولویت‌بندی



به تفکیک P0، P1، P2 و P3.



\## 16. موارد نیازمند اندازه‌گیری Runtime



فهرست مواردی که بدون Profiling یا Benchmark قابل تأیید نیستند.



\## 17. پیشنهادهای بهینه‌سازی



پیشنهادها را به سه گروه تقسیم کن:



\- Quick Wins

\- Medium-Term Improvements

\- Architectural Improvements



برای هر پیشنهاد، مزایا، پیچیدگی و ریسک تغییر را مشخص کن.



\## 18. Developer Confirmation Required



مواردی که به اطلاعات حجم داده، تعداد کاربران، الگوی ترافیک یا زیرساخت وابسته هستند.



\---



\## 22. Final Performance Quality Checklist



Before finalizing the analysis, verify:



\- \[ ] Main execution paths have been identified.

\- \[ ] CPU-intensive operations have been investigated.

\- \[ ] Memory allocation and resource lifecycle have been reviewed.

\- \[ ] Database query patterns have been examined.

\- \[ ] ORM loading behavior has been considered.

\- \[ ] API response sizes and pagination have been reviewed.

\- \[ ] Blocking and asynchronous execution patterns have been examined.

\- \[ ] Concurrency and synchronization risks have been investigated.

\- \[ ] Network and external dependency costs have been considered.

\- \[ ] Existing caching behavior has been reviewed.

\- \[ ] File and storage I/O have been examined.

\- \[ ] Background jobs and queues have been investigated.

\- \[ ] Scalability assumptions have been evaluated.

\- \[ ] Observability and available metrics have been identified.

\- \[ ] Static risks are distinguished from measured bottlenecks.

\- \[ ] Performance claims are supported by evidence.

\- \[ ] Recommendations consider correctness and operational risks.

\- \[ ] No load or stress tests have been performed without permission.

\- \[ ] No source code or configuration has been modified.

\- \[ ] The final report is written in Persian.



If runtime evidence is unavailable, explicitly state that performance conclusions are preliminary.

