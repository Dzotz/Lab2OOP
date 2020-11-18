<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html"></xsl:output>
  <xsl:template match="/">
    <html>
      <body>
        <table border="1">
          <TR>
            <th>Name</th>
            <th>Kind</th>
            <th>Price</th>
            <th>Country</th>
            <th>Caffeine</th>
            <th>Roasting</th>
            <th>Grind</th>
          </TR>
          <xsl:for-each select="CoffeeKinds/Coffee">
            <tr>
              <td>
                <xsl:value-of select="@Name"/>
              </td>
              <td>
                <xsl:value-of select="@Kind"/>
              </td>
              <td>
                <xsl:value-of select="@Price"/>
              </td>
              <td>
                <xsl:value-of select="@Country"/>
              </td>
              <td>
                <xsl:value-of select="@Caffeine"/>
              </td>
              <td>
                <xsl:value-of select="@Roasting"/>
              </td>
              <td>
                <xsl:value-of select="@Grind"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>