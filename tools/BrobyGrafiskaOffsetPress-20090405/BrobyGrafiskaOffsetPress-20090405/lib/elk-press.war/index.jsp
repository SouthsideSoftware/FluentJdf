<?xml version="1.0" encoding="iso-8859-1"?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml"
	xmlns:jsp="http://java.sun.com/JSP/Page">
<head>
<meta http-equiv="content-type" content="text/html;charset=iso-8859-1" />
<title>Elk (build @build.number@, @build.timestamp@)</title>
<link rel="stylesheet" type="text/css" media="all" href="css/screen.css" />
</head>
<body bgcolor="#ffffff">
<h1>Elk</h1>
<p>Welcome to Elk - a reference implementation of a JDF device that
implements level 3 of the <em> Worker Interface </em> of CIP4's <em>
Base ICS </em> . Your Manager software, such as a MIS, can connect to
Elk using the URL <strong> http://<%=request.getServerName() + ":" + request.getServerPort() + request.getContextPath()%>/jmf </strong> . You
can also monitor Elk using the web-based user interface below:</p>
<ul>
	<li><a href="queue?cmd=showQueue"> View Queue </a></li>
	<li><a href="config?cmd=showConfig"> View Configuration </a></li>
	<li><a href="config?cmd=showSubscriptions"> View Subscriptions </a></li>
	<li><a href="simu?cmd=showConfSimu"> View Simulation Phases 
    <li><a href="auth?cmd=showAuthentication">Manage trust relations</a></li>
</a></li>
</ul>
<%-- Servlet API 2.4 -
<p>Welcome to Elk - CIP4's JDF device reference implementation. You can send JMF messages to Elk using the URL <strong>http://<jsp:expression>request.getLocalAddr()+":"+request.getLocalPort()</jsp:expression>/elk/jmf</strong> (or http://<jsp:expression>request.getLocalName()+":"+request.getLocalPort()</jsp:expression>/elk/jmf).</p>
--%>
<p>You can find more information about the Elk project at the project's
web site <a href="http://www.cip4.org/open_source/elk/">http://www.cip4.org/open_source/elk/</a> .</p>
    <p>Elk, build @build.number@, @build.timestamp@</p>
</body>
</html>
