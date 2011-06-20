<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0" xmlns:jdf="http://www.CIP4.org/JDFSchema_1_1">
    <xsl:output method="xml"/>
    <xsl:template match="/">
        <!-- Print stylesheet -->
        <xsl:element name="xsl:stylesheet">
            <xsl:attribute name="xmlns:jdf">http://www.CIP4.org/JDFSchema_1_1</xsl:attribute>
            <xsl:attribute name="version">1.0</xsl:attribute>
            <xsl:element name="xsl:output">
                <xsl:attribute name="method">html</xsl:attribute>
            </xsl:element>
            
            <!-- xsl:template match="/" -->
            <xsl:element name="xsl:template">
                <xsl:attribute name="match">/</xsl:attribute>
                <html>
                    <head> </head>
                    <body>
                        <xsl:apply-templates select=".//jdf:DeviceCap"/>
                    </body>
                </html>
            </xsl:element>  
            
            <!-- xsl:template match="//JDF[@Type='...']" -->
            <xsl:element name="xsl:template">
                <xsl:attribute name="match">//jdf:JDF[@Type='<xsl:value-of select="//jdf:DeviceCap/@Types"/>']</xsl:attribute>
                
                <div class="resources">               
                    <h2>Input Resources</h2>
                    <ul>
                        <xsl:element name="xsl:apply-templates">                
                            <xsl:attribute name="select">jdf:ResourceLinkPool/*[@Usage='Input']</xsl:attribute>
                        </xsl:element>                        
                    </ul>
                </div>
                
            </xsl:element>
            
            <!-- xsl:template match="ResourceLinkPool/*" -->
            <xsl:apply-templates select="//jdf:DeviceCap/jdf:DevCaps[@LinkUsage='Input']"/>
            
        </xsl:element>
    </xsl:template>
    
    <xsl:template match="//jdf:DeviceCap">
        <xsl:element name="xsl:apply-templates">
            <!-- TODO Support more than one type in DeviceCap/@Types -->
            <xsl:attribute name="select">//jdf:JDF[@Type='<xsl:value-of select="@Types"/>']</xsl:attribute>
        </xsl:element>
    </xsl:template>
    
    <xsl:template match="//jdf:DeviceCap/jdf:DevCaps[@LinkUsage='Input']">
        <xsl:element name="xsl:template">                
            <xsl:attribute name="match">//jdf:ResourceLinkPool/jdf:<xsl:value-of select="@Name"/>Link[@Usage='Input']</xsl:attribute>
            <!-- Look up Resource in ResourcePool -->
            <xsl:element name="xsl:variable" >
                <xsl:attribute name="name">rRef</xsl:attribute>
                <xsl:attribute name="select">@rRef</xsl:attribute>
            </xsl:element>
            <xsl:variable name="path">//jdf:ResourcePool/jdf:<xsl:value-of select="@Name"/>[@ID=$rRef]/</xsl:variable>
            
            <!-- Get data from DevCaps' child DevCap -->
            <li>                
                <!-- Path: <xsl:value-of select="$path"/><br /> -->
                <xsl:value-of select="jdf:DevCap/jdf:Loc/@Value"/> - <xsl:value-of select="jdf:DevCap/jdf:Loc/@HelpText"/><br />
                Status: <xsl:element name="xsl:value-of"><xsl:attribute name="select"><xsl:value-of select="$path"/>@Status</xsl:attribute>
                </xsl:element><br />
                <!-- Get data recursively from child DevCap elements -->
                <xsl:if test="jdf:DevCap/jdf:DevCap">
                    <ul>
                        <xsl:apply-templates select="jdf:DevCap/jdf:DevCap">
                            <xsl:with-param name="path">//jdf:ResourcePool/jdf:<xsl:value-of select="@Name"/>[@ID=$rRef]/</xsl:with-param>
                        </xsl:apply-templates>
                    </ul>
                </xsl:if>
            </li>            
        </xsl:element>
    </xsl:template>
    
    
    <xsl:template match="jdf:DevCaps[not(@LinkUsage)]"/>

    <xsl:template match="jdf:DevCaps[@LinkUsage='Output']"/>
    
    
    <xsl:template match="jdf:DevCap">
        <xsl:param name="path"/>        
        <li>
            <!-- Path: <xsl:value-of select="$path"/><br /> -->
            <label><xsl:value-of select="jdf:Loc/@Value"/></label> - <xsl:value-of select="jdf:Loc/@HelpText"/><br />

            <xsl:for-each select="child::node()">
                <xsl:if test="contains(name(),'State')">
                    <!-- TODO Name should end with 'State' -->
                    <xsl:call-template name="State">
                        <xsl:with-param name="path"><xsl:value-of select="$path"/>jdf:<xsl:value-of select="../@Name"/>/@<xsl:value-of select="@Name"/></xsl:with-param>
                    </xsl:call-template>                                        
                </xsl:if>
            </xsl:for-each>
            
            <xsl:if test="jdf:DevCap">
                <ul>
                    <xsl:apply-templates select="jdf:DevCap">
                        <xsl:with-param name="path"><xsl:value-of select="$path"/>jdf:<xsl:value-of select="@Name"/>/</xsl:with-param>
                    </xsl:apply-templates>
                </ul>
            </xsl:if>          
        </li>
    </xsl:template>
    
    <xsl:template name="State">
        <xsl:param name="path"/>
        <em><xsl:value-of select="jdf:Loc/@Value"/>: </em>
        <xsl:element name="xsl:value-of" >
            <xsl:attribute name="select"><xsl:value-of select="$path"/></xsl:attribute>
        </xsl:element>
        <em>- <xsl:value-of select="jdf:Loc/@HelpText"/></em><br />
    </xsl:template>
    
</xsl:stylesheet>
