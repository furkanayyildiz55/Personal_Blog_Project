## Subresource Integrity

If you are loading Highlight.js via CDN you may wish to use [Subresource Integrity](https://developer.mozilla.org/en-US/docs/Web/Security/Subresource_Integrity) to guarantee that you are using a legimitate build of the library.

To do this you simply need to add the `integrity` attribute for each JavaScript file you download via CDN. These digests are used by the browser to confirm the files downloaded have not been modified.

```html
<script
  src="//cdnjs.cloudflare.com/ajax/libs/highlight.js/11.9.0/highlight.min.js"
  integrity="sha384-xBsHBR6BS/LSlO3cOyY2D/4KkmaHjlNn3NnXUMFFc14HLZD7vwVgS3+6U/WkHAra"></script>
<!-- including any other grammars you might need to load -->
<script
  src="//cdnjs.cloudflare.com/ajax/libs/highlight.js/11.9.0/languages/go.min.js"
  integrity="sha384-WmGkHEmwSI19EhTfO1nrSk3RziUQKRWg3vO0Ur3VYZjWvJRdRnX4/scQg+S2w1fI"></script>
```

The full list of digests for every file can be found below.

### Digests

```
sha384-0OZaeLK1yb5eP3nW4y0JP1fVharSrsuv/1mkI/6/8aRFm9laYIWIMXjCOqu+vRW5 /es/languages/c.js
sha384-G7WtwjMBNGrPly3ZsbPhfnT0v88hG3Ea9fQhrSWfzj7cNAsXsU7EKMQLyLGj7vTH /es/languages/c.min.js
sha384-XT4oRe1NeFTZXGmTo1gp7cuec9Ap/64f/vt4I5GMRCj3pobm/sNDBZMhJsK/xlBZ /es/languages/cmake.js
sha384-O4LQvDBqImUEPey0HB0Cg3aMyXEf/P4KYm+7uDjqqeU0+ciFh6wEQd3jkRbLD7G7 /es/languages/cmake.min.js
sha384-Wjwd1YEG/PYlkLHTWIx+RlPK6XboMN3bEpveERJ8D8Z4RaNE02Ho19ZFrSRPGi0j /es/languages/cpp.js
sha384-Q4zTNH8WsDVdSZbiZtzWS1HmAUcvMSdTmth9Uqgfjmx7Qzw6B8E3lC9ieUbE/9u4 /es/languages/cpp.min.js
sha384-Sp8E1Lb9fNhbvqBiogM60TCgpAIwYBi8WbHhIHcXO0bR5Z+9LeYwpDa1gkjzU99W /es/languages/csharp.js
sha384-huUb4Ol37G1WrtGV7bn1UArXcJSjD4tQswMGzgpNZYAPxR74MHTqW79z1dXWMvhk /es/languages/csharp.min.js
sha384-DA5ii4oN8R2fsamNkHOanSjuN4v7j5RIuheQqnxMQ4cFnfekeuhwu4IdNXiCf+UU /es/languages/css.js
sha384-OBugjfIr093hFCxTRdVfKH8Oe3yiBrS58bhyYYTUQJVobk6SUEjD7pnV8BPwsr8a /es/languages/css.min.js
sha384-bc2UqZSUiSGf9OCEBYY7hW5Z9xBeTP/36QysoLKPdOZe3+Wc28zArPV8zcM/w73J /es/languages/dart.js
sha384-uieyxXCuKHe7O9+gaoPS12wjInN2v7cKQZSKKCcm7mwSDZf5UidK7G4iMHvbZKRe /es/languages/dart.min.js
sha384-+Knm0ftuanxtMyjy6F060PlVQeYLBYyhRSdUrERbAjlJcHv2XTwe2gbWB3omFV5h /es/languages/excel.js
sha384-R5EduCTSW2/YlL/qKgN18FII8GE9/D4fJnSNpih/gNUzPDoiu8intnPNdulWELkT /es/languages/excel.min.js
sha384-WFJdA9Hz+G9NQx5vPba/tcGyIibm57UkKVY32wNB/94iT2FmPma5W7gY8p2l6qps /es/languages/java.js
sha384-coaxfgI2lKuDqSxfMlfyPq5WM0THaLGyATZHzaFMrWdIbPcLdduuItTe6AmT/m33 /es/languages/java.min.js
sha384-WCznKe2n87QvV/L1MlXN+S8R6NPUQGU34+AqogMuWGZJswSD6rt3Mgih+xuKlDgm /es/languages/javascript.js
sha384-eGsBtetyKPDKaLiTnxTzhSzTFM6A/yjHBQIj4rAMVaLPKW5tJb8U6XLr/AikCPd+ /es/languages/javascript.min.js
sha384-12GbYFzdyZCSmfBTmO2CR/qE89K5uE1PEuJ3QUwXH0Q9u+uoLNigjH9dG7LAxxiI /es/languages/json.js
sha384-+DT7AtubDhVDciRc6CgjJJRsCt0L8NC3Dh8n9Tj2tZWU8rWxDIj1ViubmUDn8OCY /es/languages/json.min.js
sha384-tsX5LI0gdW2Xk9ZMsj7B2vRchm3jC0zoc1r99Z1377aXFJJXimRtRYQprUJpSuu0 /es/languages/kotlin.js
sha384-mfmdbPhLobPr5OJzSXlWHDQDymRYyzedurWjJBvKVhlQGE+Jz/pN3D9lPEBIkDK2 /es/languages/kotlin.min.js
sha384-UgQTewauLJ4EgpADCJ99JfEtiPvw+fyaSrY1gtCVBviDNG7yCH5U7qutYptSfYk+ /es/languages/makefile.js
sha384-aUXBqKsjOzPD/W+hccF21KKWmWts/CrY/lWGJU+dAcsKtuh1/XtyDnzfLmqy/fV1 /es/languages/makefile.min.js
sha384-6eW/GwBjd1p/IWWvPhtlCq8ZV/viLec5e+CL+RdqEVMAfnyfcuqhDzNA/eADmRK0 /es/languages/pgsql.js
sha384-zOSNwldQX3ufsVxttzdDmDOl9B8zrMIbr7l0ixGfdle/Ree4OxUJK7kQjCDqT45z /es/languages/pgsql.min.js
sha384-JBkI+6623OoC1qCgG+MY/Ta0qRYSzTDH4NGMA+7U8RNOjkh7geFvYpRidvdHs3zT /es/languages/php.js
sha384-6Znh5S5q9F0hGNMtdaihFL3RJeMqL1a/UecjgzaBrhoxe4sjd5aiEOgokt7blhSW /es/languages/php.min.js
sha384-+5oyk7Ed3OlvEWGj8xracq/6e52BScKUN4kxcreNwB7kfRTVsAMs/aAJM58dzIFN /es/languages/python.js
sha384-ND/UH2UkaeWiej5v/oJspfKDz9BGUaVpoDcz4cof0jaiv/mCigjvy7RQ7e+3S6bg /es/languages/python.min.js
sha384-lRhSX2XDrY27NzrAS1t4YaeRtwjsY41kFBbIEYltkmnsfSE7lbBJMQVds2u/MqTT /es/languages/scss.js
sha384-RDUehV4j9Do6iGkYq9Gjn3aUxh6x+NFER1sHpLUXsNoCFjah8Ysrlad8ukLbIr4J /es/languages/scss.min.js
sha384-dzLjhd9nNJH62idgKI1vZEKHRBtZXSgwWQdPR+emG7tfAN4BW2g+A5Xs2315Uxii /es/languages/shell.js
sha384-RKUoelG22/D7BV/bNpoGLNzdTgWRf/ACQX7y4BGyIzK6E+xUoXtm68WNQW2tSW8X /es/languages/shell.min.js
sha384-rBAFhyrcRcMNbVJ9g4k5y3eQDkjGdgoOb3oTWTbHgwyUgUNv3CK9wLsGy/d+52oa /es/languages/sql.js
sha384-8G3qMPeOeXVKZ0wGzMQHgMVQWixLw3EXFAcU+IFNLRe0WoZB5St3L3ZLTK62Nzns /es/languages/sql.min.js
sha384-B6XNN+tQFI6cb/bizGIoHqASsFpNSzhB4rXEhX6IrjEdHLeJaR6Onmx2+ArhvnCm /es/languages/vbnet.js
sha384-LdqDRVWxc7cPE2ISZcBIeHoQAyfnXmEArz0layp8fOjceievL8eX9cV+HgneOkQ4 /es/languages/vbnet.min.js
sha384-OFoR8IZ+CFwcY8plx8HSDZNoCwLxc701CwdNGfoIEhSgwAbwhvInaxnEi3HYTt2Q /es/languages/xml.js
sha384-yFd3InBtG6WtAVgIl6iIdFKis8HmMC7GbbronB4lHJq3OLef3U8K9puak6MuVZqx /es/languages/xml.min.js
sha384-MX3xn8TktkjONV3aWF6Qn6WZyq2Lh/98p0v7D0qEoJ4WLdYjoAyXF/L/80q3qaEc /es/languages/yaml.js
sha384-4IiaMbQ0LBiRJYBGoAXsN+dV9qu/cGLES6IuVowdeCu/FAMY5/MQfD/bHXoL2YBb /es/languages/yaml.min.js
sha384-VZxKf0mjKYDwZIgrW+InqDfJ0YwYUFEMw/4YmpV1oKtVXFVmVq/Ga1vgq6zKTUqS /languages/c.js
sha384-mWenE7UXKnmYRcJ3mh+Os3iZ43BmFf9x3AZMM6gi/2sT6vxouPWspbTdREwWDO3w /languages/c.min.js
sha384-/DE6n+XheQ/kdrhU7A+cWj1GSRUM44zfgDDcWPvIeGGr02ckG45tZIoLbVgx4X1h /languages/cmake.js
sha384-iqJTnKrAPlpoueHQticEO1SgUDmD+Lv1EGplrE41YfNgnnVCt6pLeVjutOnr/Ddi /languages/cmake.min.js
sha384-J4Ge+xXjXgzbK2FP+OyzIGHLfKU/RR0+cH4JJCaczeLETtVIvJdvqfikWlDuQ66e /languages/cpp.js
sha384-LMyrRAiUz6we2SGvYrwDd4TJoJZ+m/5c+4n4E64KVkfWFcZdlrs4Wabr0crMesyy /languages/cpp.min.js
sha384-8sbRwiU8Ar2M7+w//1u7YiI1e7KsmB4k3QbW/m1IW5FVH51HiOpR7g5QGE3RqTNi /languages/csharp.js
sha384-wWP4JQEhRVshehTP7lUMDn3yhDI2+398vN2QW5LBt1xIpK0Gfu4dPviO8tP9XRo5 /languages/csharp.min.js
sha384-r9czyL17/ovexTOK33dRiTbHrtaMDzpUXW4iRpetdu1OhhckHXiFzpgZyni2t1PM /languages/css.js
sha384-HpHXnyEqHVbcY+nua3h7/ajfIrakWJxA3fmIZ9X9kbY45N6V+DPfMtfnLBeYEdCx /languages/css.min.js
sha384-j+Z8AbaxtIbQNvVYsXvFl/JeeYS/NFILMRoBJJegZcoIpgXk7KLJYlwdoMvBK44I /languages/dart.js
sha384-9N7m4GS3gPm6zFPGhkir0Vn61SBcmTq2ZIlgNo6Jm3N2khSHxFvQ9rJ5WRfX5WlN /languages/dart.min.js
sha384-VnH0twJ1N+XQ4ORynlCOgsH/agkOZpwx6hRkwyopZh4RfUGjOdDGgSZRNF5VMnGo /languages/excel.js
sha384-yZpyX3GaZ2n2wTQboLuT4pMbAyEK+icy793eW60VdZdVZMw5g5jxArbZtFkh+6ri /languages/excel.min.js
sha384-pYIeBYeCE96U9EkPcT4uJjNWyrB1BKB41JIadYJbvmGa5KacaoXtSQOUpBfeyWQX /languages/java.js
sha384-uUg+ux8epe42611RSvEkMX2gvEkMdw+l6xG5Z/aQriABp38RLyF9MjDZtlTlMuQY /languages/java.min.js
sha384-vJxw3XlwaqOQr8IlRPVIBO6DMML5W978fR21/GRI5PAF7yYi2WstLYNG1lXk6j9u /languages/javascript.js
sha384-44q2s9jxk8W5N9gAB0yn7UYLi9E2oVw8eHyaTZLkDS3WuZM/AttkAiVj6JoZuGS4 /languages/javascript.min.js
sha384-dq9sY7BcOdU/6YaN+YmFuWFG8MY2WYJG2w3RlDRfaVvjdHchE07Ss7ILfcZ56nUM /languages/json.js
sha384-RbRhXcXx5VHUdUaC5R0oV+XBXA5GhkaVCUzK8xN19K3FmtWSHyGVgulK92XnhBsI /languages/json.min.js
sha384-UjoANPpyYDKhhXCD7M94TUBIvEg+Yey//mTGwAKIPkAcmpT4QVk8D47YYWumt/ZR /languages/kotlin.js
sha384-vfngjS9mwSs6HkzR9wU3mDDip7sa8TLKAxsuQ9+ncUHU25slHzHOdx/0FWxvbg4I /languages/kotlin.min.js
sha384-LmfE+sO0d5qZL2Ka0DIrgJ/5U1plo4uFFAmgjcMxrQO+RkeWVYWuaphHAdrY9g7V /languages/makefile.js
sha384-NIrob3StFQyD/nlOsXVCeRsJ0N2SvFEDjFtYS393wbD3CY1eT+2kwT4RL7tpMMhs /languages/makefile.min.js
sha384-FbyEf9EotuzOvgY88yzeCiAnYTkV2uHiY+FkYU9uH1jJY/DmF8IvxDo0rnl4n3ug /languages/pgsql.js
sha384-Oo+KBAbqcXAtR0/yFlZsRvJSAITfvxhJ761p5yOO4pyEtYO6n/5j6eVI1dG8aGct /languages/pgsql.min.js
sha384-S1JDGPScVg8ikNKLZc4CSP0ZxLiJ7bOJMzTLfOzQiCxR6wPqAa+YtauHJXQpc2GV /languages/php.js
sha384-c1RNlWYUPEU/QhgCUumvQSdSFaq+yFhv3VfGTG/OTh8oirAi/Jnp6XbnqOLePgjg /languages/php.min.js
sha384-zdZio5RcGiKQJCpe/1IXujPle3bIY8sbmvCabSU5G5GzWAzZtoRZfg9QAQXCL08q /languages/python.js
sha384-IP4vv4Aoh9Lyg8QyzVkAmn2JGoDCpgVHzVSrD3Z+rVyn7+s4wx4pRjv+go3TEwfj /languages/python.min.js
sha384-fwYddFsITuK2bPhi9RuIzwi4PTULEXgtEJsQzTdx97vOS/GHfrk+aNSLxEHgzQa5 /languages/scss.js
sha384-6u+QpCDqQidb5pcO+yBqy0xLJ30x30VlrFvXm8J84LMwGIw9q3U4u+Z9vFXlhB5x /languages/scss.min.js
sha384-KW3ZDReTAemYUfVHvH1MNQ/v6agCYYdMGdMteP/yVV+NetIJeDMx0ruUMTbr/SD3 /languages/shell.js
sha384-PDEMny3uYpCrSKwqVGLAwqCsc9u+9hYXauxVPqO6RXmlxSNKLoRByEBigU5lahmK /languages/shell.min.js
sha384-Dy7I/j0yJlyliWiNrkNqXfxDrbN65q40s3JColgTYZQ7QJa7lcmK0WUL3i00/T51 /languages/sql.js
sha384-8q00eP+tyV9451aJYD5ML3ftuHKsGnDcezp7EXMEclDg1fZVSoj8O+3VyJTkXmWp /languages/sql.min.js
sha384-NRGkScJ2K7VJUsHL7H9eHncQMh99wPeeOYyPkHZiUfihAg+Xb0j1JotJI3DkqX5f /languages/vbnet.js
sha384-+y0KLxbRrWxqnfGRhWWQTHHEwDd1OhkOacgf5QfJa+5ydoCf3SWObb+XrzxBSfqa /languages/vbnet.min.js
sha384-+PuZYFfVX2UQZU2yKt/FsJUZNUPzZWxW7auXltsaecr1xLvzBYF3c5gYoyOs1++x /languages/xml.js
sha384-jgkY4GMNWfQcLLIoP1vg3FWXflDrRhcSXGBW6ONIWC2SOIv5H1Pa57sXs+aomCuZ /languages/xml.min.js
sha384-tB5cwwsX4Ddp7P4d+ZInDb3nt4ihEEglHXoQ18eVLlT7soEn7bfGfABWKIn1l+H2 /languages/yaml.js
sha384-WC56y8OaFPt5Kj2HX6JAumxUYEjQmBDcSTJy2pn/N8g7dg1hKjeNVrJYoxlpeVmz /languages/yaml.min.js
sha384-LE1G23k8X467bno8xsMNcC6N1CvoKbfMWruZvFH692Nnw/KjKpyv7SpRdP2FxF4r /highlight.js
sha384-YCJ7fSDafCTckHbGDkV/DOE8NWKP99plvyYHjkGRflK180XfGTIdtfCoJ86QlBQq /highlight.min.js
```

