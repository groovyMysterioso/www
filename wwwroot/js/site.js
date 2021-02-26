// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var extractedLinks = [];

function LinkExtractor() {
    var PostContent = $('textarea#Content').val();
    var re = new RegExp(/(?:https?:\/\/)?(?:youtu\.be\/|(?:www\.|m\.)?youtube\.com\/(?:watch|v|embed)(?:\.php)?(?:\?.*v=|\/))([a-zA-Z0-9\_-]+)/);
    var youtubeLink = re.exec(PostContent);
    

    if (youtubeLink != null) {
        if (extractedLinks.indexOf(youtubeLink[0]) < 0) {
            var video_id = youtubeLink.toString().split('v=')[1];
            var ampersandPosition = video_id.indexOf('&');
            if (ampersandPosition != -1) {
                video_id = video_id.substring(0, ampersandPosition);
            }
            var youTubeEmbed = '<iframe width="560" height="315" src="https://www.youtube.com/embed/' + video_id + '" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>';
            $('div#embed-code').append(youTubeEmbed);
            extractedLinks.push(youtubeLink[0]);

        }
    }
    else if (redditLink != null) {
        if (extractedLinks.indexOf(redditLink[0]) < 0) {
            
            var redditEmbed = generateEmbed(redditLink[0]).then(function () {
            $('div#embed-code').append(redditEmbed);
            extractedLinks.push(redditLink[0]);
            });

        }
    }
    else {
        $('div#embed-code').html("");
        extractedLinks = [];
    }

}

function LinkExtractorDiv(DivToParse) {
    var PostContent = $(DivToParse).text();
    var re = new RegExp(/(?:https?:\/\/)?(?:youtu\.be\/|(?:www\.|m\.)?youtube\.com\/(?:watch|v|embed)(?:\.php)?(?:\?.*v=|\/))([a-zA-Z0-9\_-]+)/);
    var youtubeLink = re.exec(PostContent);
    const regPatt = /reddit\.com\/r\/[^\/]+\/comments\/([^\/]{6,})\//;

    var checkReddit = new RegExp(regPatt);
    var redditLink = checkReddit.exec(PostContent);
    if (youtubeLink != null) {
        if (extractedLinks.indexOf(youtubeLink[0]) < 0) {
            var video_id = youtubeLink[0].toString().split('v=')[1];
            var ampersandPosition = video_id.indexOf('&');
            if (ampersandPosition != -1) {
                video_id = video_id.substring(0, ampersandPosition);
            }
            var youTubeEmbed = '<iframe width="500" height="315" src="https://www.youtube.com/embed/' + video_id + '" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>';
            $(DivToParse).parent().find('div.embed-code').append(youTubeEmbed);

        }
    }
    else if (redditLink != null) {
        if (extractedLinks.indexOf(redditLink[0]) < 0) {
            
            var redditEmbed = generateEmbed(redditLink[0]);
            $(DivToParse).parent().find('div.embed-code').append(redditEmbed);
            extractedLinks.push(redditLink[0]);

        }
    }


}
function AttachmentAttacher(DivToRead) {
    var attachmentsString = $(DivToRead).parent().find('input.attachment-code').val().split(",");
    for (var  i = 0; i < attachmentsString.length; i++)
    {
        var ext = attachmentsString[i].substr(attachmentsString[i].length - 3);

        switch (ext) {
            case "jpg":
            case "jpeg":
                $(DivToRead).parent().find('div.embed-code').append('<img style="width:100%" src="\\PostedFiles\\' + attachmentsString[i]+'"/>');

                break;
            case "mpg":
            case "mp4":
                var videoHtml = '<video width="100%" controls><source src="\\PostedFiles\\'
                    + attachmentsString[i] + '" type="video/mp4">';
                $(DivToRead).parent().find('div.embed-code').append(videoHtml);
                break;
            case "mp3":
                var audioHtml = '<audio controls><source src="\\PostedFiles\\'
                    + attachmentsString[i] + '" type="video/mp4">';
                $(DivToRead).parent().find('div.embed-code').append(audioHtml);
                break;

        }
    }
}
function generateEmbed(url) {
    const regPatt = /reddit\.com\/r\/[^\/]+\/comments\/([^\/]{6,})\//;
    if (regPatt.test(url)) {
        const fullname = 't3_' + regPatt.exec(url)[1];
         var returnObject = fetch(`https://api.reddit.com/api/info/?id=${fullname}`)
            .then(res => res.json())
            .then(json => generateEmbedFromRedditJson(json));
    }
    else {
        alert('Please enter a valid reddit post URL.')
    }
}

/**
 * Parse and generate embed from API response
 * @param {Object} redditJson 
 */
function generateEmbedFromRedditJson(redditJson) {
    const selfData = redditJson.data.children[0].data;
    const { author, permalink, score, thumbnail, title, url } = selfData;
    const subreddit = selfData.subreddit_name_prefixed;

    const html = `
	<div class="reddit-embed">
		<div class="header">
			<div class="poster">Posted by ${author}</div>
			<div class="title"><a href="${permalink}" target="_blank">${title}</a></div>
		</div>
		<div class="body-left">
			<div class="imageWrapper">
				<img src="${thumbnail}" />
			</div>
		</div>
		<div class="body-right">
			<div class="score">${String.fromCharCode(0x2195)} = ${score}</div>
		</div>
	</div>
	`;

    return html;
}
