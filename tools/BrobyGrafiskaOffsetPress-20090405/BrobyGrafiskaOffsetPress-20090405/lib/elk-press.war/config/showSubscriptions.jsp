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
<title><fmt:message key='app.name' /> - <fmt:message key='subscriptions' /></title>
<link rel="stylesheet" type="text/css" media="all" href="css/screen.css" />
</head>
<body>
	<div id="config">
        <c:set var='subscriptions' value='${subscriptions}'/>
        <h1><fmt:message key='subscriptions'/></h1>
        <table>
        <thead>
            <tr>
                <th><fmt:message key='channel.id'/></th>
                <th><fmt:message key='url'/></th>
                <th><fmt:message key='message.type'/></th>
                <th><fmt:message key='initiating.message'/></th>
                <th></th>
             </tr>
        </thead>
        <tbody>
            <c:forEach var='sub' items='${subscriptions.subscriptions}'>                
                <tr>
                    <td>${sub.id}<a/></td>
                    <td>${sub.url}</td>
                    <td>${sub.messageType}<a/></td>
                    <td><code><c:out value="${sub.query}" escapeXml="true"/></code></td>
                    <td><a href="<c:url value='/config?cmd=deleteSubscription&channel=${sub.id}&url=${sub.url}'/>">Delete</a></td>
                </tr>
            </c:forEach>
         </tbody>
     </table>	
</body>
</html>
