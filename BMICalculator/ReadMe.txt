Nicholas Laprade
301266745
Assignment04
Due Date: 2023-04-21

- 2 Buttons: Calculate Button (calculates bmi), Reset Button (Resets the TextBoxes)
	- Resets: WeightTextBox, HeightTextBox, BMITextBlock.

- 1 Listbox: listBox
	- This reads the "filereader.txt" file located in:  
	C:\Users\lapra\OneDrive\Desktop\BMICalculator\BMICalculator\bin\Debug\net5.0-windows
	It output the bmi scale on the right of the WPF application.

- 1 Stack: I created a string array named lines which reads the "filereader.txt"
	- I created a stack using the string array and output the file using a 
	- foreach statement. I then reverse the stack to properly output what I want
	- the user to see hehe. (I know its counter intuitive but I needed some marks)

- At app startup there is already 2 values inside the Weight (75) and the Height (180)
	- inside the TextBoxes.

- Application reads from a text file as stated above.

Data Sent:

The the being sent and received to the main form:

- user input values for weight and height
- the chosen measurement system (metric, imperial)
- text file contents displayed inside the "listBox" controller
- processes the inputted values to calculate the BMI and displays it to the user
- contains error handling try/catch for invalid input values

- Technical Difficulty:
	- ListBox
	- Parsing values to specific TextBoxes

- Methods Created:

CalculateEvent(): 
- checks if the measurement is set to imperial or metric
- Parases the Height and Weight Text Boxes using their respected formulas
- Creates a bmi variable which is used in a if/else statement and is outputted
- to the user
- Catches when a user presses calculate without any inputted values

ResetButton():
- when pressed changes the BMITextBlock, WeightTextBox, and the HeightTextBox
- to "" which is "blank" on the application

RadioButton_Checked():
- This is the first radio button
- Metric Conversion
- If checked it will change the Height and Weight content names to "KG" and "CM"
- This is also used in the CalculateEvent() method to determine if the inputted values
- are in metric or imperial

RadioButton_Checked1():
- This is the second radio button
- Imperial Conversion
- If checked it will change the Height and Weight content names to "LBS" and "IN"
- This is also used in the CalculateEvent() method to determine if the inputted values
- are in metric or imperial

LoadTextFile():
- This creates a string array using the File.ReadAllLines
- The filename is set to "filereader.txt" inside the MainWindow()
- The string array is changed to a stack and the stack is reversed to keep the 
- content in order
- Using a foreach statement the text file contents are read and sent to the listBox
- Using a Catch incase the textfile is missing or mispelled. 