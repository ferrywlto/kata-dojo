- Block by user (block malicious behaviors)
- Block by IP (block traffic)
- Block by resource (protect expensive resource)

Approaches
- Redis (distributed cache) bucket with reset time
- Simple hard bucket (block X secs after Y access), problem with burst access around bucket boundary
- Cron timer to refill access, but requires computation and long running job