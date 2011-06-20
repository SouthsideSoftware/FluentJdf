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
<title><fmt:message key='app.name' /> - <fmt:message
    key='configuration' /></title>
<link rel="stylesheet" type="text/css" media="all" href="css/screen.css" />
</head>
<body>
<div id="config"><c:set var='config'
    value='${requestScope.config}' /> <c:set var='preprocessor'
    value='${requestScope.preprocessor}' />
<h1><fmt:message key='device.configuration' /></h1>
<ul>
    <li><label title="<fmt:message key='device.deviceID.help'/>"><fmt:message
        key='device.deviceID' />:</label> ${config.deviceID}</li>
    <li><label title="<fmt:message key='device.agentName.help'/>"><fmt:message
        key='device.agentName' />:</label> ${config.agentName}</li>
    <li><label
        title="<fmt:message key='device.agentVersion.help'/>"><fmt:message
        key='device.agentVersion' />:</label> ${config.agentVersion}</li>
    <li><label
        title="<fmt:message key='device.publicBaseDir.help'/>"><fmt:message
        key='device.publicBaseDir' />:</label> ${device.publicBaseDir}</li>
    <li><label
        title="<fmt:message key='device.publicBaseUrl.help'/>"><fmt:message
        key='device.publicBaseUrl' />:</label> ${device.publicBaseUrl}</li>    
</ul>
<p><a href="config/Device.xml"><fmt:message
    key='view.device.capabilities.file' /></a></p>
</div>


</body>
</html>
