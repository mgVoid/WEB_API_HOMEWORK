### We need Web API number ordering solution. This solution should have 2 endpoints:
- We can pass line of numbers from 1 - 10 (few can be skipped) and these numbers should be ordered and saved to file (for ex. result.txt). For ex. we pass 5 2 8 10 1, this file should be saved with following content 1 2 5 8 10.
- We should be able to load content of latest saved file.
### Usage:
- Clone the repository.
- Run the application.
- Swagger should open up, this is one of the ways to use the endpoints.
- To query through postman, pass it as a JSON body.(Ex. JSON data to pass: "{ "IntList": [ 22, 33, 44, 33, 0, 3, -1, 4] }")
- http://localhost:7170/api/getperformance/{"insert the performance test array size(an integer)"} to receive the compared sorting efficiency.
- http://localhost:7170/api/getdata for receiving the latest data which has been posted. 
- http://localhost:7170/api/postdata to post the data to get sorted and saved to the text file.
- By default the generated text files are saved in C:\AppData\
