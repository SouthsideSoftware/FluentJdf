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
<title><fmt:message key='app.name' /> - <fmt:message key='queue' /></title>
<link rel="stylesheet" type="text/css" media="all" href="css/screen.css" />
</head>
<body>
	<div id="queue">
	<h1><fmt:message key='queue'/></h1>
	<p>
	<c:set var='queue' value='${requestScope.queue}'/>
    <label><fmt:message key='queue.size'/>:</label> ${queue.queueSize}<br />
    <label><fmt:message key='queue.status'/>:</label> ${queue.queueStatus.name}<br />
    </p>
    <table>
         <thead>
             <tr>
                 <th><fmt:message key='job.id'/>(<fmt:message key='part.id'/>)</th>
                 <th><fmt:message key='status'/></th>
                 <th><fmt:message key='priority'/></th>
                 <th><fmt:message key='submission.time'/></th>
                 <th><fmt:message key='start.time'/></th>
                 <th></th>  
             </tr>
         </thead>
         <tbody>
             <c:forEach var='qe' items='${queue.queueEntryVector}'>                
                 <tr>
                     <td><a href="<c:url value='/job?cmd=showJob&id=${qe.queueEntryID}'/>">${qe.jobID} (${qe.jobPartID})</a></td>                     
                     <td>${qe.queueEntryStatus.name}</td>
                     <td>${qe.priority}</td>
                     <td>${qe.submissionTime.dateTimeISO}</td>
                     <td>
                     <%
                     // Get the JDFQueueEntry object declared in JSTL loop above
                     org.cip4.jdflib.jmf.JDFQueueEntry qe = (org.cip4.jdflib.jmf.JDFQueueEntry) pageContext.getAttribute("qe");
                     %>
                     <%= qe.getAttribute("StartTime") %>
                     <%-- ${qe.startTime==null} --%>
                     </td>
                     <td><a href="<c:url value='/queue?cmd=showQueueSubmissionParams&qeid=${qe.queueEntryID}'/>"><fmt:message key='view.submission.params'/></a></td>
                 </tr>
             </c:forEach>
         </tbody>
     </table>
     </div>
	
	
</body>
</html>
