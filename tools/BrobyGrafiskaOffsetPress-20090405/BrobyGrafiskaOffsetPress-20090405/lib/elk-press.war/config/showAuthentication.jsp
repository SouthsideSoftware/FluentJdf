<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
	pageEncoding="ISO-8859-1"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt"%>
<%@ taglib prefix="x" uri="http://java.sun.com/jsp/jstl/xml"%>
<fmt:setBundle basename="org.cip4.elk.helk.messages.messages" />
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1" />
<title><fmt:message key='app.name' /> - <fmt:message key='configuration' /></title>
<link rel="stylesheet" type="text/css" media="all" href="css/screen.css" />
</head>
<body>
	<div id="auth">
	<h1>Trust relations</h1>
	<p>
	<c:set var='auth' value='${requestScope.authHandler}'/>
	<c:set var='nsurl' value='${requestScope.nsurl}'/>
    <label>Local HTTPS URL:</label> ${auth.secureUrl}<br />
    <form action="<c:url value='/auth'/>" method=get>
    	<label>Connected name server:</label>
    	<input type="hidden" name="cmd" value="register">
     	<input type="text" name="url" value="${nsurl}" size=40 maxlength=60>
     	<input type="submit" value="Refresh"></td>
    	</form>
	<br />
    </p>
    
    <table>
         <thead>
             <tr>
                 <th>Remote role</th>
                 <th>Remote party</th>
                 <th>Remote party URL</th>
                 <th>Local Status</th>
                 <th>Remote Status</th>
                 <th>Secure URL</th>  
                 <th>Accept</th>  
                 <th>Revoke</th>  
                 <th>View certificate</th>  
             </tr>
         </thead>
         <tbody>
             <c:forEach var='te' items='${auth.trustEntries}'>                
                 <tr>
                     <%--
                     <td><a href="<c:url value='/job?cmd=showJob&id=${qe.queueEntryID}'/>">${qe.jobID} (${qe.jobPartID})</a></td>
                     --%>
                     <td>${te.remoteRole}</td>
                     <td>${te.remoteID}</td>
                     <td>${te.remoteUrl}</td>
                     <td>${te.localStatusString}</td>
                     <td>${te.remoteStatusString}</td>
                     <td>${te.remoteSecureUrl}</td>
                     <c:if test="${te.localStatus=='1'}">
                     	<td><a href="<c:url value='/auth?cmd=accept&id=${te.remoteID}&role=${te.role}'/>">Accept</a></td>
                     </c:if>
                     <c:if test="${te.localStatus!='1'}">
                        <td>Accept</td>
                     </c:if>
                     <c:if test="${te.localStatus<'3'}">
                     	<td><a href="<c:url value='/auth?cmd=reject&id=${te.remoteID}&role=${te.role}'/>">Revoke</a></td>
                     </c:if>
                     <c:if test="${te.localStatus>'2'}">
                        <td>Revoke</td>
                     </c:if>
                     <td><a href="<c:url value='/auth?cmd=view&id=${te.remoteID}&role=${te.role}'/>">View certificate</a></td>    
                 </tr>
             </c:forEach>
         </tbody>
     </table>
   
    <label>Add trust relation:</label><br />
    <form action="<c:url value='/auth'/>" method=get>
    <input type="hidden" name="cmd" value="new">
     <table>
        <thead>
           <tr>
              <th>Remote party name:</th>
              <th>Remote party URL</th>
              <th></th>
           </tr>
        </thead>
        <tbody>
           <tr>
              <td><input type="text" name="name" value="" size=40 maxlength=60></td>
              <td><input type="text" name="url" value="http://" size=40 maxlength=60></td>
 			  <td><input type="submit" value="Submit"></td>
           </tr>
        </tbody>
     
     </table>
     </form>
     </div>
	
	
</body>
</html>
