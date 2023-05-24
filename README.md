Program, using lecture notes, interconnected structures Time and TimePeriod that meet the following requirements:

<h1>Time Structure</h1>

A variable of type Time describes a point in time within the range 00:00:00...23:59:59 (consider modulo arithmetic for hours %24 and minutes and seconds %60 when it makes sense and is required).

![TimePeriod](https://github.com/OlafGrzesiak/Time-TimePeriod/assets/115358036/06525bd7-ab1a-4d30-b97f-d68b3bb71558)

<h1>Time & TimePeriod</h1>

The internal representation of time consists of byte fields: Hours, Minutes, Seconds – implement them as properties.

Ensure immutability of created variables of type Time.

Provide different construction variants (including three parameters: hour, minute, second; two parameters: hour, minute, with seconds defaulting to 0; one parameter: hour; a string parameter in the format hh:mm:ss, and potentially others, as needed), ensuring proper variable construction and raising appropriate exceptions for invalid data.

Implement the standard text representation of time (in the format hh:mm:ss) by overriding the ToString() method.

Implement the interfaces IEquatable<Time> and IComparable<Time> to define a natural ordering in the "time points" set and overload relational operators (==, !=, <, <=, >, >=).

Provide arithmetic operations on time (modulo 24 hours) – plus, minus, for example, methods Time Plus(TimePeriod), static Time Plus(Time, TimePeriod), and overloading the + operator.

  <h1>TimePeriod Structure</h1>

A variable of type TimePeriod represents a duration of time (the distance between two points in time, the duration).

Internally, represent the duration as the number of seconds (long data type).

Provide an "external representation" in the format h:m:s – note: a value of 12:25:23 for TimePeriod indicates a time duration of 12 hours, 25 minutes, and 23 seconds, whereas the same representation for Time indicates a point on the time axis: twelve twenty-five and 23 seconds. Note: a TimePeriod variable with a value of 29:58:12 makes sense, meaning a time period of 29 hours, 58 minutes, and 23 seconds, whereas it doesn't make sense in the Time type.

Ensure immutability of created variables of type TimePeriod.

Provide different construction variants (including three parameters: number of hours, number of minutes, number of seconds; two parameters: number of hours, number of minutes; one parameter: number of seconds; two Time parameters to calculate the difference between time points; a string parameter in the format h:mm:ss, and potentially others, as needed), ensuring proper variable construction and raising appropriate exceptions for invalid data.

Implement the standard text representation of time duration (in the format h:mm:ss) by overriding the ToString() method, allowing values like 129:58:12.

Implement the interfaces IEquatable<TimePeriod> and IComparable<TimePeriod>, and overload relational operators (==, !=, <, <=, >, >=).

Provide arithmetic operations on time periods – plus, minus, for example, methods TimePeriod Plus(TimePeriod), static TimePeriod Plus(TimePeriod, TimePeriod), and overloading the + operator, as well as other operations as needed.

Test the correctness of the designed structures by creating appropriate unit tests.

Here's the translation of the requirements into English.
