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
<title><fmt:message key='app.name' /> - <fmt:message key='job' /></title>
<link rel="stylesheet" type="text/css" media="all" href="css/screen.css" />
</head>
<body>
    <c:set var='jdf' value='${requestScope.jdf}'/>
    <%--  
    <c:set var='jobInfo' value='${requestScope.jobInfoHtml}'/>
    <c:import var='xsl' url='${requestScope.xsl}'/>
    <h1>Job</h1>
    <div id="job">
        <c:out value='${jobInfo}'/>
        
        <strong>JDF:</strong>
        <c:out value='${jdf}' escapeXml='true'/><br />
        <strong>XSL:</strong>
        <c:out value='${xsl}' escapeXml='true'/><br />
        <strong>HTML:</strong>
        <x:transform xml='${jdf}' xslt='${xsl}'/>
                <c:out value='${jobInfo}' escapeXml='false'/>
        <x:parse var='xsl' systemId='${requestScope.xsl}'/>        
    </div>
    --%>

    <h1>Job</h1>
    <div id="job">        
        <label>Job Part ID:</label> ${jdf.jobPartID}<br />
        <label>Type:</label> ${jdf.type}<br />
        <label>Description:</label> ${jdf.descriptiveName}<br />
    
        <h2>Input Resources</h2>
        <ul>
        <c:forEach var='input' items='${requestScope.inputLinks}'>
            <li>
            <label>ID:</label> ${input.linkTarget.ID}<br />
            <label>Status:</label> ${input.linkTarget.status.name}<br />
            <label>Type:</label> ${input.linkTarget.resourceType}<br />
            <label>Class:</label> ${input.linkTarget.resourceClass.name}<br />
            <label>Description:</label> ${input.linkTarget.descriptiveName}<br />
            </li>
        </c:forEach>
        </ul>
        
        <h2>Output Resources</h2>
        <ul>
        <c:forEach var='output' items='${requestScope.outputLinks}'>
            <li>
            <label>ID:</label> ${output.linkTarget.ID}<br />
            <label>Status:</label> ${output.linkTarget.status.name}<br />
            <label>Type:</label> ${output.linkTarget.resourceType}<br />
            <label>Class:</label> ${output.linkTarget.resourceClass.name}<br />
            <label>Description:</label> ${output.linkTarget.descriptiveName}<br />
            </li>
        </c:forEach>
        </ul>
        
        <h2>Audits</h2>
        <ul>
        <c:forEach var='audit' items='${requestScope.audits}'>
            <li>
            <label>Type:</label> ${audit.auditType.name}<br />
            <label>Timestamp:</label> ${audit.timeStamp}<br />
            <label>Author:</label> ${audit.author}<br />
            <label>Agent:</label> ${audit.agentName}<br />
            </li>
        </c:forEach>
        </ul>
		<a href="job?cmd=showJDF&id=${param.id}&mime=text/xml"><fmt:message key="view.jdf"/></a>
     </div>
</body>
</html>
