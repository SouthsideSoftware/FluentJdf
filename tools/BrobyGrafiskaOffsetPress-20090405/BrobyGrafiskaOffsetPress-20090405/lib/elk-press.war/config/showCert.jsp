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
	<div id="Certificate info">
	<h1>Certificate info</h1>
	<p>
	<c:set var='trustEntry' value='${requestScope.trustEntry}'/>
    <label>Remote ID: </label>${trustEntry.remoteID}<br />
    <label>Remote URL: </label>${trustEntry.remoteUrl}<br />
    <label>Remote host info: </label>${trustEntry.remoteHostInfo}<br />
    <label>Remote party role: </label>${trustEntry.remoteRole}<br />    
    </p>
    <p>
    <label>Trust entry remote certificate</label><br />
 	${trustEntry.remoteCertificate} <br />
    </p>
    <p>
    <label>Trust entry remote certificate</label><br />
 	${trustEntry.certInfo}<br />
    </p>
    </div>
	
	
</body>
</html>
