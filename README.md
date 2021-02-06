# BIGDATA-ANALYSIS

## 1st project
### Preprocessing program
Program reads points (x,y,z,i) from the .txt file and put them into sorted list (sorted by X,Y).<br> Then program saves points structure as binary file.

<b>Run the program with parameters:</b><br>
*input_file*   - input file with raw ASCII points data <br>
*preprocessed_file*  - output file where points are preprocessed

### Histogram program
Program read file chunk by chunk. Chunk size is definied by user as <b>M</b> parameter.<br> Then program adds points that exsists in bounding box definied in parameters by user.<br> Program uses binary search to find first point from bounding box inside chunk.<br> By <b>Histogram</b> class program calculates every needed parameter to display statistics.

<b>Run the program with parameters:</b><br>
 *M*                - maximum size of memory usage <br>
 *minX*              - minimum X value of points of interest<br>
 *maxX*              - maximum X value of points of interest<br>
 *minY*              - minimum Y value of points of interest<br>
 *maxY*              - maximum Y value of points of interest<br>
 *bin_size*          - size of histogram bin used in statistics calculation<br>
 *selection*         - enable switching of which point parameter should be used for statistics summary, either intensity (i) or point height (z).
 
 #### Input file format
 *394372.82 39157.52 217.57 61 <br>
394372.82 39165.22 218.13 39<br>
394372.82 39186.13 221.59 46*
### Example
 #### Run with parameters: 
 *output 1 394364 394374 39150 39160 5 i*
 #### Output
 *Number of points inside given bounding box: 1031<br>
Calculated average: 37,3346<br>
Calculated deviation: 19,7108<br>
Calculated skewness: 1,22782<br>
Calculated kurtosis: 4,83795<br>
Number of bins: 26<br>
Number of data reads from the input file: 37*

## 2nd project
### Regression program
Program creates linear regression for:
- **Linear function - single variable**<br>
- **General linear function - multiple variables**<br>
- **Polynomialfunction**<br>
<p>Program detects if points inside .txt file belongs to polynomial function or general linear function with multiple variables. <br>Program also calculates degree of the function if the function is polynomial.</p>

#### Run the program
You can run this console application without any parameters.
### Input file format (1st format)
*X Y<br>
10.6888 49264.7<br>
12.3991 39068.8<br>
33.5362 -1.25108e+006*
### Input file format (2nd format)
*X1 X2 X3 X4 Y<br>
391.675 776.33 263.619 891.171 13950.1<br>
200.781 813.898 492.538 970.763 15888.7<br>
289.987 681.57 126.347 431.013 10149.2*
### Output example for linear function (single variable)
*c: 7,1594446690634115<br>
b1 : 3,1000057728440162*
### Output example for general linear function (4 variables)
*c: 1,0441290229898121 <br>
b1 : 0,10002800516499116<br>
b2 : 11,100030011339015<br>
b3 : 5,200130397807429<br>
b4 : 4,400084763095325*
### Output example for polynomial function (degree: 4)
*c: 61005,01752105124<br>
b1 : 5,609798431396484<br>
b2 : -0,031225020997226238<br>
b3 : 2,096800643252209<br>
b4 : -1,0999521179519434*
