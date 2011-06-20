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
<div id="simu">
<h1>Simulation Phases for Conventional Printing</h1>
<normal>
Simulation phases are hard coded in the Elk source. To alter the phases take a look into the package org.cip4.elk.simulation. The phases are generated in the ConfSimuHandler class.
</normal>
<p><c:set var='simu' value='${requestScope.simu}' /> <label>
Phases table:</label><br />
</p>
<table border="1" cellspacing="2" cellpadding="5">
	<thead>
		<th align="center" valign="middle">Phase</th>
		<th align="center" valign="middle">DeviceStatus</th>
		<th align="center" valign="middle">DeviceStatusDetails</th>
		<th align="center" valign="middle">DeviceSpeed</th>
		<th align="center" valign="middle">PhaseLength <br /><small>the PhaseLength of DeviceStatus=Running depends on the percentage of the TotalAmount that should be produced according to the DeviceSpeed </small></th>
		<th align="center" valign="middle">WasteAmount<br /><small>as  percentage of the TotalAmount</small>
		</th>
		<th align="center" valign="middle">GoodAmount<br /><small>as percentage of the TotalAmount</small></th>
		<th width="100" align="center" valign="middle">Comment</th>
	</thead>
	<tbody>
		<%int counter = 0;%>

		<c:forEach var='si' items='${simu.simuPhases}'>
			<tr>

				<td align="center" valign="middle"><%=(counter = counter + 1)%></td>


				<td align="center" valign="middle">${si.simulationPhase.name}</td>
				<td align="center" valign="middle">${si.statusDetails.name}</td>
				<td align="center" valign="middle">${si.deviceSpeed}</td>
				<td align="center" valign="middle">${si.phaseLength}</td>
				<td align="center" valign="middle">${si.wasteVariance} &#37;</td>
				<td align="center" valign="middle">${si.goodVariance} &#37;</td>
				<td width="300" align="center" valign="middle">${si.jmfComment}</td>


			</tr>
		</c:forEach>
	</tbody>
</table>


</div>


</body>
</html>
