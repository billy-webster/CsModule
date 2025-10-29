# CourseWork - C# Console Application

## Overview
This is a C# console application that provides three main functionalities:
1. **Trinary Converter** - Converts trinary numbers to decimal
2. **School Roster System** - Manages student records across different forms
3. **ISBN Verifier** - Validates ISBN codes

The application features a menu-driven interface with ASCII art and colored console output.

## Features

### 1. Trinary Converter
- Converts trinary numbers (base-3) to decimal format
- Input validation to ensure only valid trinary digits (0, 1, 2) are accepted
- Error handling for invalid inputs

### 2. School Roster System
A comprehensive student management system with three sub-features:

- **Add Students**: Add students to specific forms using "Name,Form" format
- **Check Students**: Find which form a student belongs to
- **View Forms**: Display all students in a specific form

Uses a 2D array (250×7) to store student data where:
- Rows represent student entries
- Columns represent forms (0-6)

### 3. ISBN Verifier
- Validates 13-digit ISBN codes
- Supports both numeric and 'X' as the final digit
- Comprehensive input validation and error handling

## Technical Details

### Project Structure
```
CourseWork.cs
```

### Key Components

- **Main Menu System**: Navigate between different functionalities
- **Input Validation**: Robust error handling throughout the application
- **Thread Sleep**: Used for better user experience with timed delays
- **Console Styling**: Green text color and ASCII art for visual appeal

### Data Structures
- **2D String Array**: For storing student records (250×7)
- **Character Arrays**: For processing ISBN and trinary numbers
- **String Manipulation**: For formatting and displaying data

## How to Use

1. **Compile and Run** the application
2. **Main Menu** appears with three options:
   - `a` - Trinary Converter
   - `b` - School Roster System  
   - `c` - ISBN Verifier
   - `q` - Exit program

3. Follow the on-screen instructions for each feature

## Input Formats

### Trinary Converter
- Input: Valid trinary number (digits 0-2 only)
- Example: `101` → Output: `10`

### School Roster
- Add Students: `StudentName,FormNumber`
- Example: `Billy,3`
- Check Students: Enter student name
- View Forms: Enter form number

### ISBN Verifier
- Input: 13-digit ISBN code
- Example: `3-598-21508-8` → Output: `Valid`

## Code Structure

### Main Classes and Methods

- **`Main()`** - Entry point with welcome screen
- **`Menu()`** - Main navigation system
- **`TrinaryConverter()`** - Handles trinary conversion
- **`TrinaryToDecimal()`** - Conversion algorithm
- **`CheckValidity()`** - Input validation for trinary numbers
- **`SchoolRoster()`** - School system menu
- **`AddStudents()`** - Add students to database
- **`CheckStudents()`** - Search for students
- **`ViewForms()`** - Display form lists
- **`ISBNVerifier()`** - ISBN validation system
- **`HandlingError()`** - ISBN input validation
- **`ISBN_Validator()`** - ISBN verification algorithm

## Testing

The code includes comprehensive test data covering:
- Valid and invalid inputs for all features
- Edge cases and error conditions
- Expected vs actual outputs

## Error Handling
- Input validation for all user inputs
- Try-catch blocks for exception handling
- User-friendly error messages
- Graceful recovery from invalid inputs

## Requirements
- .NET Framework
- C# Compiler
- Console environment

## Compilation and Execution
```bash
csc CourseWork.cs
CourseWork.exe
```

This application demonstrates fundamental programming concepts including arrays, string manipulation, input validation, and menu-driven interfaces suitable for a first-year university assignment.
