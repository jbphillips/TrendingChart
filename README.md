# TrendingChart


## Tech:
- VS 2022 .NET 7.0
- DevExpress.Blazor 23.1.4

## Life purpose of this app:
Excercise a DevExpress Blazor Line Chart with Blazor Server

## Big walk aways from this excercise:
- Handling JSON data within Blazor
- Displaying chart data from JSON file
- Configuring and minipulating a DevExpress chart
- Implementing custom services
- Calculating trending data

# Overview of what is happening:
- The main page is a hack, demoing a way the enter the trending line chart with data. Not much to look at here
- When the button on the main page is pressed, it fetches json data from data folder and accesses the needed chart data
- The chart maintains a fixed upper and lower threshold and an adjustable tolerance level
- The datapoints pulled from the JSON file are sent to Calculate Trendlind object and a trendline is calculated and returned
- The data points have expandable tooltips
- The tooltips have access to a custom dialog presenting more information about its data
- Additional information includes a link to a pdf builder providing a custom view of that data overall. (custom view is blurred)

![My DevExpress LineChart](https://raw.githubusercontent.com/jbphillips/TrendingChart/master/Screenshot.png)

