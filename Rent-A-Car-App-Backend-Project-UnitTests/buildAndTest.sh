#!/bin/bash

# Build the solution
dotnet build

# Run unit tests
dotnet test --no-build


send_email() {
    Success=$1
    ToEmail="lodhia@seattleu.edu"  

    EmailBody=$(cat <<EOF
Build Succeeded: $Success
Tests Passed: $Success
EOF
)

    # Send email using mail command 
    echo "$EmailBody" | mail -s "Test Suite Status" "$ToEmail"
}

# Check the exit code of the last command
if [ $? -eq 0 ]; then
    # Tests passed, send success email
    echo "Tests Passed: True"
    send_email true
else
    # Tests failed, send failure email
    echo "Tests Passed: False"
    send_email false
fi


