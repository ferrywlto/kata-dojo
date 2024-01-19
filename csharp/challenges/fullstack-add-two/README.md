# This resembles the live coding challenge I created for candidates in WATI

### Notes:

- Time allowed: within 1 hour.
- You need to use Visual Studio Code with C# and/or JavaScript programming language to finish your tasks.
- You need to create the project from scratch, without copying code from other project or from the Internet.
- Please share your whole desktop instead of just a single window so we can see what you are doing.
- You are encouraged to express what you are trying to do during the session.

### Preparation

Below are what you need to prepare in order to ensure you perform the best in the interview:

- Development environment you used in your daily work.
    - Visual Studio Code
    - .NET6+ or NodeJS 18+ or Python 3 SDK
    - git and GitHub CLI
    - Docker desktop with common images pulled from your daily development tasks
    - NPM/YARN with Frontend SDK of your choice installed
    - Other tools (database tools, Postman, terminals)
        - Terminals (Mac)
        - Command Prompt (Windows)
        - Studio3T
- Ensure your computer can share your whole desktop in Google meet.

### Tasks:

- [ ]  Create and init a GitHub repository by command line (CLI)
- [ ]  Create a minimal HTTP POST API backend to accept 2 integers (Num1 and Num2) and return the sum, the API endpoint should look similar to this: `POST http://localhost/add`, you should create the API server with command line and IDE with keyboards only, using mouse-clicks on GUI buttons is prohibited.
- [ ]  Call the API with `curl` in command line only.
- [ ]  Commit and push to git in command line only.
- [ ]  Write a unit test with xUnit framework (for .NET) or (Jest for NodeJS) for your add method, execute the test from command line only.
- [ ]  Demonstrate storing 2 integers and sum into persistence storage. 
Inspect the persistence storage to confirm the insert operation did happened.
Use a MongoDb docker container for that. Then use Studio3T to inspect.
- [ ]  Create a minimal UI frontend with either tech of your choice (preferably ReactJS) with command line only, it should have 2 input boxes for integers, a button to send the request to backend and a label to display the result.
- [ ]  Build frontend and backend into 2 docker images via command line only.
- [ ]  Run both frontend and backend docker container via command line only.
- [ ]  Demonstrate calling backend docker container from frontend docker container, inspect persistence storage to ensure new record inserted via Studio3T.