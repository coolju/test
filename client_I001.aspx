<%@ Page Language="C#" AutoEventWireup="true" CodeFile="client_I001.aspx.cs" Inherits="client_I001" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     
  
    <!-- Materializecss compiled and minified CSS -->
<link href="./css/materialize.css" type="text/css" rel="stylesheet" media="screen,projection"/>
<link href="./css/style.css" type="text/css" rel="stylesheet" media="screen,projection"/>

<!--Import Google Icon Font-->
<link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
<!--Import Materialize-Stepper CSS (after importing materialize.css) -->
<link rel="stylesheet" href="./css/materialize-stepper.min.css" />






    <!-- Responsive -->
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>AIR - Gestion client</title>
</head>
<body>
<div class="container">
<form id="form1" runat="server">
       
        <header>
            <%
            Response.WriteFile("./include/nav.inc");
            %>
        </header>

<blockquote>
<h5>Création client</h5>
<div class="divider"></div>
</blockquote>

<main>

    <ul class="stepper linear">
   <li class="step active">
      <div class="step-title waves-effect">CLIENT</div>
      <div class="step-content">
         <div class="row">
            <div class="input-field col s12">
               <input id="gdo" name="gdo" type="text" class="validate" required="required" />
               <label for="gdo">GDO</label>
            </div>
         </div>
          <div class="row">
            <div class="input-field col s12">
               <input id="raisonSociale" name="raisonSociale" type="text" class="validate" required="required" />
               <label for="raisonSociale">RAISON SOCIALE</label>
            </div>
         </div>
         <div class="step-actions">
            <button class="waves-effect waves-dark btn next-step">CONTINUE</button>
         </div>
      </div>
   </li>
   <li class="step">
      <div class="step-title waves-effect">CONTACTS</div>
      <div class="step-content">
         <div class="row">
            <div class="input-field col s6">
               <input id="contact1_nom" name="contact1_nom" type="text" class="validate" required="required" />
               <label for="contact1_nom">CONTACT</label>
            </div>
            <div class="input-field col s6">
               <input id="contact1_num" name="contact1_num" type="text" class="validate" required="required" />
               <label for="contact1_num">NUMERO MOBILE</label>
            </div>
         </div>

          <div class="row">
            <div class="input-field col s6">
               <input id="contact2_nom" name="contact2_nom" type="text" class="validate" />
               <label for="contact2_nom">CONTACT</label>
            </div>
            <div class="input-field col s6">
               <input id="contact2_num" name="contact2_num" type="text" class="validate" />
               <label for="contact2_num">NUMERO MOBILE</label>
            </div>
         </div>

          <div class="row">
            <div class="input-field col s6">
               <input id="contact3_nom" name="contact3_nom" type="text" class="validate"/>
               <label for="contact3_nom">CONTACT</label>
            </div>
            <div class="input-field col s6">
               <input id="contact3_num" name="contact3_num" type="text" class="validate" />
               <label for="contact3_num">NUMERO MOBILE</label>
            </div>
         </div>

         <div class="step-actions">
            <button class="waves-effect waves-dark btn next-step">CONTINUE</button>
            <button class="waves-effect waves-dark btn-flat previous-step">BACK</button>
         </div>
      </div>
   </li>
   <li class="step">
      <div class="step-title waves-effect">VALIDER!</div>
      <div class="step-content">
         Finish!
         <div class="step-actions">
            <button class="waves-effect waves-dark btn" type="submit">VALIDER</button>
         </div>
      </div>
   </li>
</ul>

</main>

    
<!-- jQuery -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
<!-- Materializecss compiled and minified JavaScript -->
<script src="./js/materialize.js"></script>
<!-- jQueryValidation Plugin -->
<script src="https://ajax.aspnetcdn.com/ajax/jquery.validate/1.15.0/jquery.validate.min.js"></script>
<!--Import Materialize-Stepper JavaScript (after the jquery.validate.js and materialize.js) -->
<script src="./js/materialize-stepper.min.js"></script>

<script type="text/javascript">

        $(function(){
            $('.stepper').activateStepper();
    });




    $(function () {
        $(document).ready(function () {
            // the "href" attribute of the modal trigger must specify the modal ID that wants to be triggered
            $('.button-collapse').sideNav();
        });
    });
</script>

    
</form>
</div> <!-- Container--> 
</body>
</html>
