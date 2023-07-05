using CSharpCamp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace CSharpCamp
{
    public class Problem
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int RequiredInputs { get; set; }
        public List<string> Examples { get; set; } = new List<string>();
        public List<TestCase> TestCases { get; set; } = new List<TestCase>();
        public string? ExampleSolution { get; set; }
    }

    public class TestCase
    {
        public string? Input { get; set; }
        public string? ExpectedOutput { get; set; }
    }

    public class Globals
    {
        public string? Input { get; set; }
    }
    public partial class MainWindow : Window
    {
        private readonly List<Problem> _problems = new List<Problem>();

        public MainWindow()
        {
            InitializeComponent();
            LoadProblems();
            ProblemSelector.ItemsSource = _problems;
            ProblemSelector.DisplayMemberPath = "Title";
            CodeEditor.Text = @"
// Your code here 
var data = Input.Split(',');

var answer = ;

return answer;";
        }

        private void LoadProblems()
        {
            // Problem 1
            var sumIntegers = new Problem
            {
                Title = "1. Sum of Integers",
                Description = "Given two integers in the form 'a,b', return their sum.",
                RequiredInputs = 2,
                ExampleSolution = "var data = Input.Split(',');\nint sum = 0;\nforeach (var num in data)\n{\n    sum += int.Parse(num);\n}\nreturn sum.ToString();\n"
            };
            sumIntegers.Examples.Add("Input: 1,2\nOutput: 3");
            sumIntegers.Examples.Add("Input: 3,4\nOutput: 7");
            sumIntegers.TestCases.Add(new TestCase { Input = "1,2", ExpectedOutput = "3" });
            sumIntegers.TestCases.Add(new TestCase { Input = "3,4", ExpectedOutput = "7" });
            sumIntegers.TestCases.Add(new TestCase { Input = "5,5", ExpectedOutput = "10" });
            sumIntegers.TestCases.Add(new TestCase { Input = "10,-20", ExpectedOutput = "-10" });
            _problems.Add(sumIntegers);

            // Problem 2
            var productIntegers = new Problem
            {
                Title = "2. Product of Integers",
                Description = "Given two integers, return their product.",
                RequiredInputs = 2,
                ExampleSolution = "var data = Input.Split(',');\nint product = 1;\nforeach (var num in data)\n{\n    product *= int.Parse(num);\n}\nreturn product.ToString();\n"
            };
            productIntegers.Examples.Add("Input: 2,3\nOutput: 6");
            productIntegers.Examples.Add("Input: 4,5\nOutput: 20");
            productIntegers.TestCases.Add(new TestCase { Input = "2,3", ExpectedOutput = "6" });
            productIntegers.TestCases.Add(new TestCase { Input = "4,5", ExpectedOutput = "20" });
            productIntegers.TestCases.Add(new TestCase { Input = "-6,7", ExpectedOutput = "-42" });
            productIntegers.TestCases.Add(new TestCase { Input = "-10,-10", ExpectedOutput = "100" });
            _problems.Add(productIntegers);

            // Problem 3
            var reverseString = new Problem
            {
                Title = "3. Reverse String",
                Description = "Reverse a string.",
                RequiredInputs = 1,
                ExampleSolution = "var data = Input;\nvar charArray = data.ToCharArray();\nvar reversed = \"\";\n\nfor (int i = charArray.Length - 1; i >= 0; i--)\n{\n    reversed += charArray[i];\n}\n\nreturn reversed;\n"
            };
            reverseString.Examples.Add("Input: Hello\nOutput: olleH");
            reverseString.Examples.Add("Input: CSharp\nOutput: prahSC");
            reverseString.TestCases.Add(new TestCase { Input = "Hello", ExpectedOutput = "olleH" });
            reverseString.TestCases.Add(new TestCase { Input = "CSharp", ExpectedOutput = "prahSC" });
            reverseString.TestCases.Add(new TestCase { Input = "Programming", ExpectedOutput = "gnimmargorP" });
            reverseString.TestCases.Add(new TestCase { Input = "Algorithm", ExpectedOutput = "mhtiroglA" });
            _problems.Add(reverseString);

            // Problem 4
            var checkPalindrome = new Problem
            {
                Title = "4. Is Even Length",
                Description = "Given a string, check if the length of the string is even. The output should be a literal string of 'True' or 'False'",
                RequiredInputs = 1,
                ExampleSolution = "var data = Input;\nint length = data.Length;\nbool isEvenLength = length % 2 == 0;\nreturn isEvenLength.ToString();"
            };
            checkPalindrome.Examples.Add("Input: Bool\nOutput: True");
            checkPalindrome.Examples.Add("Input: Hello\nOutput: False");
            checkPalindrome.TestCases.Add(new TestCase { Input = "Bool", ExpectedOutput = "True" });
            checkPalindrome.TestCases.Add(new TestCase { Input = "Hello", ExpectedOutput = "False" });
            checkPalindrome.TestCases.Add(new TestCase { Input = "Test", ExpectedOutput = "True" });
            checkPalindrome.TestCases.Add(new TestCase { Input = "Python", ExpectedOutput = "False" });
            _problems.Add(checkPalindrome);

            // Problem 5
            var calculateFactorial = new Problem
            {
                Title = "5. Calculate Factorial",
                Description = "Calculate the factorial of a number.",
                RequiredInputs = 1,
                ExampleSolution = "var data = int.Parse(Input);\nvar answer = 1;\nfor (var i = data; i > 0; i--)\n{\n    answer *= i;\n}\nreturn answer.ToString();\n"
            };
            calculateFactorial.Examples.Add("Input: 5\nOutput: 120");
            calculateFactorial.Examples.Add("Input: 3\nOutput: 6");
            calculateFactorial.TestCases.Add(new TestCase { Input = "5", ExpectedOutput = "120" });
            calculateFactorial.TestCases.Add(new TestCase { Input = "3", ExpectedOutput = "6" });
            _problems.Add(calculateFactorial);

            // Problem 6
            var fibonacci = new Problem
            {
                Title = "6. Fibonacci Sequence",
                Description = "Generate the Fibonacci sequence up to a given number.",
                RequiredInputs = 1,
                ExampleSolution = "var n = int.Parse(Input);\nif (n == 0) return \"0\";\nvar a = 0;\nvar b = 1;\nvar res = \"1\";\nfor (var i = 2; i <= n; i++)\n{\n    var temp = a;\n    a = b;\n    b = temp + b;\n    res += \",\" + b.ToString();\n}\nreturn res;\n"
            };
            fibonacci.Examples.Add("Input: 5\nOutput: 1,1,2,3,5");
            fibonacci.TestCases.Add(new TestCase { Input = "5", ExpectedOutput = "1,1,2,3,5" });
            fibonacci.TestCases.Add(new TestCase { Input = "7", ExpectedOutput = "1,1,2,3,5,8,13" });
            _problems.Add(fibonacci);

            // Problem 7
            var primeCheck = new Problem
            {
                Title = "7. Prime Number Checker",
                Description = "Check if a given number is prime. The output should be a literal string of 'True' or 'False'",
                RequiredInputs = 1,
                ExampleSolution = "var n = int.Parse(Input);\nif (n <= 1) return \"False\";\nfor (var i = 2; i * i <= n; i++)\n{\n    if (n % i == 0) return \"False\";\n}\nreturn \"True\";\n"
            };
            primeCheck.Examples.Add("Input: 5\nOutput: True");
            primeCheck.TestCases.Add(new TestCase { Input = "5", ExpectedOutput = "True" });
            primeCheck.TestCases.Add(new TestCase { Input = "4", ExpectedOutput = "False" });
            _problems.Add(primeCheck);

            // Problem 8
            var gcd = new Problem
            {
                Title = "8. Greatest Common Divisor",
                Description = "Find the GCD of two numbers.",
                RequiredInputs = 2,
                ExampleSolution = "var data = Input.Split(',');\nvar a = int.Parse(data[0]);\nvar b = int.Parse(data[1]);\nwhile (b != 0)\n{\n    var temp = b;\n    b = a % b;\n    a = temp;\n}\nreturn a.ToString();\n"
            };
            gcd.Examples.Add("Input: 48,18\nOutput: 6");
            gcd.TestCases.Add(new TestCase { Input = "48,18", ExpectedOutput = "6" });
            gcd.TestCases.Add(new TestCase { Input = "20,8", ExpectedOutput = "4" });
            _problems.Add(gcd);


            // Problem 9
            var factors = new Problem
            {
                Title = "9. Find All Factors",
                Description = "Find all factors of a number.",
                RequiredInputs = 1,
                ExampleSolution = "var number = int.Parse(Input);\nvar result = \"\";\nfor (var i = 1; i <= number; i++)\n{\n    if (number % i == 0) result += i.ToString() + \",\";\n}\nreturn result.TrimEnd(',');\n"
            };
            factors.Examples.Add("Input: 12\nOutput: 1,2,3,4,6,12");
            factors.TestCases.Add(new TestCase { Input = "12", ExpectedOutput = "1,2,3,4,6,12" });
            factors.TestCases.Add(new TestCase { Input = "18", ExpectedOutput = "1,2,3,6,9,18" });
            factors.TestCases.Add(new TestCase { Input = "24", ExpectedOutput = "1,2,3,4,6,8,12,24" });
            factors.TestCases.Add(new TestCase { Input = "30", ExpectedOutput = "1,2,3,5,6,10,15,30" });
            _problems.Add(factors);

            // Problem 10
            var multiplicationTable = new Problem
            {
                Title = "10. Generate Multiplication Table",
                Description = "Generate a multiplication table for a given number.",
                RequiredInputs = 1,
                ExampleSolution = "var number = int.Parse(Input);\nvar result = \"\";\nfor (var i = 1; i <= 10; i++)\n{\n    result += (number * i).ToString() + \",\";\n}\nreturn result.TrimEnd(',');\n"
            };
            multiplicationTable.Examples.Add("Input: 5\nOutput: 5,10,15,20,25,30,35,40,45,50");
            multiplicationTable.TestCases.Add(new TestCase { Input = "5", ExpectedOutput = "5,10,15,20,25,30,35,40,45,50" });
            multiplicationTable.TestCases.Add(new TestCase { Input = "10", ExpectedOutput = "10,20,30,40,50,60,70,80,90,100" });
            multiplicationTable.TestCases.Add(new TestCase { Input = "2", ExpectedOutput = "2,4,6,8,10,12,14,16,18,20" });
            multiplicationTable.TestCases.Add(new TestCase { Input = "7", ExpectedOutput = "7,14,21,28,35,42,49,56,63,70" });
            _problems.Add(multiplicationTable);

            // Problem 11
            var sorting = new Problem
            {
                Title = "11. Sorting",
                Description = "Implement a sorting algorithm. You need to sort a list of five integers in ascending order. The input will be a string of comma-separated five integers and the output should be a string of comma-separated five integers in sorted order.",
                RequiredInputs = 5,
                ExampleSolution = @"
string[] numbersStr = Input.Split(',');
int[] numbers = new int[numbersStr.Length];
for (int i = 0; i < numbersStr.Length; i++)
{
    numbers[i] = int.Parse(numbersStr[i]);
}
for (int i = 0; i < numbers.Length - 1; i++)
{
    for (int j = i + 1; j < numbers.Length; j++)
    {
        if (numbers[i] > numbers[j])
        {
            int temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }
    }
}
return string.Join(',', numbers);",
            };
            sorting.Examples.Add("Input: \"3,2,1,4,5\"\nOutput: \"1,2,3,4,5\"");
            sorting.TestCases.Add(new TestCase { Input = "3,2,1,9,7", ExpectedOutput = "1,2,3,7,9" });
            sorting.TestCases.Add(new TestCase { Input = "-5,-4,8,-2,-1", ExpectedOutput = "-5,-4,-2,-1,8" });
            sorting.TestCases.Add(new TestCase { Input = "10,20,30,40,-100", ExpectedOutput = "-100,10,20,30,40" });
            sorting.TestCases.Add(new TestCase { Input = "2,3,4,5,-1", ExpectedOutput = "-1,2,3,4,5" });
            _problems.Add(sorting);

            // Problem 12
            var lookAndSay = new Problem
            {
                Title = "12. Look and Say Sequence",
                Description = "Generate the nth term in the look-and-say sequence. The look-and-say sequence is a sequence of digits that is constructed by describing the previous term in the sequence. Starting with \"1\", the second term is \"11\" because the first term contains one \"1\".",
                RequiredInputs = 1,
                ExampleSolution = @"
if (int.Parse(Input) == 1) return ""1"";
string result = ""1"";
for (int i = 2; i <= int.Parse(Input); i++)
        {
            string temp = """";
    for (int j = 0; j < result.Length; j++)
            {
                int count = 1;
                while (j + 1 < result.Length && result[j] == result[j + 1])
                {
                    j++;
                    count++;
                }
                temp += count.ToString() + result[j];
            }
            result = temp;
        }
        return result; ",
            };
            lookAndSay.Examples.Add("Input: \"1\"\nOutput: \"1\"");
            lookAndSay.Examples.Add("Input: \"2\"\nOutput: \"11\"");
            lookAndSay.Examples.Add("Input: \"3\"\nOutput: \"21\"");
            lookAndSay.Examples.Add("Input: \"4\"\nOutput: \"1211\"");
            lookAndSay.TestCases.Add(new TestCase { Input = "1", ExpectedOutput = "1" });
            lookAndSay.TestCases.Add(new TestCase { Input = "2", ExpectedOutput = "11" });
            lookAndSay.TestCases.Add(new TestCase { Input = "3", ExpectedOutput = "21" });
            lookAndSay.TestCases.Add(new TestCase { Input = "4", ExpectedOutput = "1211" });
            lookAndSay.TestCases.Add(new TestCase { Input = "5", ExpectedOutput = "111221" });
            lookAndSay.TestCases.Add(new TestCase { Input = "6", ExpectedOutput = "312211" });
            _problems.Add(lookAndSay);
        }

        private void ProblemSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProblemSelector.SelectedItem is Problem selectedProblem)
            {
                ProblemDescription.Document.Blocks.Clear();
                ProblemDescription.Document.Blocks.Add(new Paragraph(new Bold(new Run(selectedProblem.Title))));
                ProblemDescription.Document.Blocks.Add(new Paragraph(new Run(selectedProblem.Description)));
                ProblemDescription.Document.Blocks.Add(new Paragraph(new Run("Examples:")));
                foreach (var example in selectedProblem.Examples)
                {
                    var border = new Border { BorderBrush = Brushes.Black, BorderThickness = new Thickness(1), Margin = new Thickness(10), Padding = new Thickness(10) };
                    var textBlock = new TextBlock { Text = example };
                    border.Child = textBlock;
                    ProblemDescription.Document.Blocks.Add(new BlockUIContainer(border));
                }
            }
        }

        private async void TestButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CodeEditor.Text))
                {
                    MessageBox.Show("Please write your code before testing.", "No Code", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(TestInput.Text))
                {
                    MessageBox.Show("Please provide input before testing.", "No Input", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var selectedProblem = ProblemSelector.SelectedItem as Problem;

                // Validate the number of inputs
                if (selectedProblem != null && TestInput.Text.Split(',').Length != selectedProblem.RequiredInputs)
                {
                    MessageBox.Show($"This problem requires exactly {selectedProblem.RequiredInputs} inputs.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var script = CSharpScript.Create(CodeEditor.Text, globalsType: typeof(Globals));
                var scriptState = await script.RunAsync(new Globals { Input = TestInput.Text });

                if (scriptState.Exception != null)
                {
                    throw scriptState.Exception;
                }

                // Replace message box with a TextBlock for output display
                MessageBox.Show(scriptState.ReturnValue.ToString(), "Test Result", MessageBoxButton.OK, MessageBoxImage.Information);

                // After running the code, clear the test input box.
                TestInput.Text = "";
            }
            catch (CompilationErrorException ex)
            {
                MessageBox.Show(string.Join("\n", ex.Diagnostics), "Compilation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void RunButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedProblem = (Problem)ProblemSelector.SelectedItem;
                if (selectedProblem != null)
                {
                    foreach (var testCase in selectedProblem.TestCases)
                    {
                        // Evaluate the script with the test case input as a global variable
                        var script = CSharpScript.Create(CodeEditor.Text, globalsType: typeof(Globals));
                        var scriptState = await script.RunAsync(new Globals { Input = testCase.Input });

                        if (scriptState.Exception != null)
                        {
                            throw scriptState.Exception;
                        }

                        // Compare the script result with the expected output
                        if (scriptState.ReturnValue.ToString() != testCase.ExpectedOutput)
                        {
                            MessageBox.Show($"Test case {testCase.Input} failed. Expected {testCase.ExpectedOutput}, but got {scriptState.ReturnValue}", "Test Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }

                    MessageBox.Show("All tests passed", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (CompilationErrorException ex)
            {
                MessageBox.Show(string.Join("\n", ex.Diagnostics), "Compilation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Runtime Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            // Display the constraints
            MessageBox.Show("Here are the constraints:\n\n1. The input is a single string or a list of strings separated by comma.\n2. The answer should be returned in the last line of the code.\n3. For multi-input problems, inputs will be separated by a comma.\n4. You can't use certain namespaces, like System.Linq, in this code editor.\n\nContacts: freelcove@gmail.com", "Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SolutionButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected problem
            var selectedProblem = ProblemSelector.SelectedItem as Problem;

            if (selectedProblem != null)
            {
                // Replace the code editor text with the example solution
                CodeEditor.Text = selectedProblem.ExampleSolution;
            }
            else
            {
                // Display a message if no problem is selected
                MessageBox.Show("Please select a problem to see its example solution.", "No Problem Selected", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void TestInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TestInput.Text == "Enter input here...")
            {
                TestInput.Text = "";
            }
        }

        private void TestInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TestInput.Text))
            {
                TestInput.Text = "Enter input here...";
            }
        }
    }
}
