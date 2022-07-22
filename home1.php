<html>
    <head>
        <title>College Bus Management System</title>
        </head>
        <body>
            <center>
<img src="MCET.jpg" align="left"><img>
<h1 >Dr. Mahalingam College of Engineering and Technology</h1><br><hr>
<br>
<h2>College Bus Management System</h2><br><br>
            <h3> The Details are listed below.</h3>
<?php 
    include('connection.php');
    if (isset($_POST['submit'])) {


        $roll_no = $_POST['roll_no'];
       
		
        $sql = "SELECT * FROM `student_details` WHERE  `roll_no`='$roll_no' ";

        $result = mysqli_query($conn,$sql);
        if (mysqli_num_rows($result)>0) {
            while ($DataRows = mysqli_fetch_assoc($result)) {
                $name = $DataRows['name'];
                $roll_no = $DataRows['roll_no'];
                $department = $DataRows['department'];
                $year = $DataRows['year'];
				$stage= $DataRows['stage'];
				$route = $DataRows['route'];
				$validity = $DataRows['validity'];
				$date_of_fee_paid = $DataRows['date_of_fee_paid'];
				$bus_no = $DataRows['bus_no'];
				$fee_status = $DataRows['fee_status'];
			
		
	    echo	"<b>NAME</b>   :  $name <br>",  
			    "<b>ROLL NUMBER</b>   :    $roll_no <br>",
				"<b>DEPARTMENT</b>    :    $department <br> ",
				"<b>YEAR</b>          :    $year <br>",
				"<b>STAGE</b>         :    $stage <br>",
				"<b>ROUTE</b>         : $route <br>",
				"<b>VALIDITY</b>      : $validity <br>",
				"<b>DATE OF FEE PAID</b> : $date_of_fee_paid <br>",
				"<b>BUS NUMBER</b>    : $bus_no <br>",
				"<b>FEE STATUS </b>   : $fee_status <br>";
				
		}
           
		}
	}	
                ?>
                </center>
                </body>
                </html>