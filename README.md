# arithmetic-tester
Learning tool for basic arithmetic

# Version 1.0 Features
1. Choice of operators (+,-, *, /)
2. Displays helper tables after second incorrect guess for a question
3. Displays the number of questions, guesses and correct answers
4. Displays a grade on test completion

## Version 1.1 Features
1. Better error handling
2. Fix bug where completion message is displayed when user reaches tenth question rather than after they've answered it
3. Fix bug #11 where the gridview.ClearSelection() was not working because it was called too early

## Version 1.2 Features
1. Add title and exclamation icon to error handling message box.

### Version 1.2.1 Features
1. Add document to explain grading system. See '.\Design Docs\Grading System.xlsx' for further details.
2. Add MIT License.

### Version 1.2.2 Features
1. Add License summary to source code files.

# Future Releases
1. Add unit tests
2. Use a configurable range of factors (beyond 1 to 12) - take data types (byte,int) into account
3. Have a configurable number of questions
4. Have a random operator to test multiple operators in same test

# License
Copyright (c) 2017 Matthew Wright.
Licensed under MIT License. See LICENSE.txt for further details.

This software should be distributed with a LICENSE.TXT file in the solution root.
Alternatively  you can find a copy of the license in the github repository:
https://github.com/wiganlatics/arithmetic-tester.
The MIT License text is also available at: https://choosealicense.com/licenses/mit/.
