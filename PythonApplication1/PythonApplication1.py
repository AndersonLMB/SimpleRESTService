import urllib2
import StringIO
from BeautifulSoup import BeautifulSoup

url = "http://www.stats.gov.cn/tjsj/tjbz/tjyqhdmhcxhfdm/2016/"
request = urllib2.Request(url)
request.add_header("User-Agent","Mozilla/5.0")

try: 
	response = urllib2.urlopen(request)
	print response.getcode()
	content = response.read()
	print content
except Exception,e: 
	print e.reason

