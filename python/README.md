# Python environment setup for Pandas Leetcode Questions

1. Check if Python installed:
```
python3 --version
```

If not:
```
brew install python3
```

2. Create virtual environment, isolated environment with a standalone python installation with pip installed in root directory:

```
python3 -m venv .
```

3. Activate the virtual environment:
```
source bin/activate
```

4. Install pytest:
```
python3 -m pip install pytest
```

5. Deactivate the virtual environment (In case needed)
```
deactivate
```

### To run test for a file
```
pytest filename.py
```

### To get output from `print()`
```
pytest -s filename.py
```

### Run all tests in a folder
```
pytest
```

**Test files must either start with `test_` or end with `_test.py`**

pytest vs unittest

| Feature           | `pytest`                          | `unittest`                        |
|-------------------|-----------------------------------|-----------------------------------|
| Installation      | Third-party (`pip install pytest`)| Built-in (part of standard library)|
| Test Structure    | Function-based                    | Class-based                       |
| Boilerplate Code  | Less                              | More                              |
| Assertions        | Simple `assert` statements        | Methods like `self.assertEqual`   |
| Advanced Features | Fixtures, parameterized testing, plugins | Limited                           |
| Test Discovery    | Automatic                         | Requires `unittest` discovery     |

