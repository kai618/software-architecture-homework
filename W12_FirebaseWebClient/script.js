// set the configuration for your app
const config = { databaseURL: "https://sprout-sa.firebaseio.com/" };
firebase.initializeApp(config);
const dbRef = firebase.database().ref();

/* event-handler methods */
function page_Load() {
  getAll();
}

function lnkID_Click(id) {
  getDetails(id);
}

function btnSearch_Click() {
  var keyword = document.getElementById("keyword").value.trim();
  if (keyword.length > 0) search(keyword);
  else getAll();
}

function btnAdd_Click() {
  addNew(getVideo());
}

function btnUpdate_Click() {
  updateVideo(getVideo());
}

function getVideo() {
  var video = {
    id: document.getElementById("video-id").value,
    uploader: document.getElementById("video-uploader").value,
    title: document.getElementById("video-title").value,
    description: document.getElementById("video-description").value,
    tags: document.getElementById("video-tags").value,
    url: document.getElementById("video-url").value,
    timestamp: document.getElementById("video-timestamp").value
  };
  return video;
}

function btnDelete_Click() {
  if (confirm("ARE YOU SURE ?")) {
    var id = document.getElementById("video-id").value;
    deleteVideo(id);
    clearTextBoxes();
  }
}

/* business methods */

function getAll() {
  dbRef.child("videos").on("value", snapshot => {
    var videos = [];
    snapshot.forEach(child => {
      var video = child.val();
      videos.push(video);
    });

    renderVideoList(videos);
  });
}

function getDetails(id) {
  dbRef.child("videos").once("value", snapshot => {
    snapshot.forEach(child => {
      var video = child.val();
      if (video.id == id) {
        renderVideoDetails(video);
      }
    });
  });
}

function search(keyword) {
  dbRef.child("videos").once("value", snapshot => {
    const videos = [];
    snapshot.forEach(child => {
      const video = child.val();
      if (video.title.toLowerCase().includes(keyword.toLowerCase()))
        videos.push(video);
    });
    renderVideoList(videos);
  });
}

function addNew(newVideo) {
  const vRef = "videos/" + newVideo.id;
  dbRef.child(vRef).once("value", snapshot => {
    if (!snapshot.exists()) dbRef.child(vRef).set(newVideo);
    else alert("FAIL! Video has already existed!");
  });
}

function updateVideo(newVideo) {
  const vRef = "videos/" + newVideo.id;
  dbRef.child(vRef).once("value", snapshot => {
    if (snapshot.exists()) dbRef.child(vRef).set(newVideo);
    else alert("FAIL! Video does not exist!");
  });
}

function deleteVideo(id) {
  const vRef = "videos/" + id;
  dbRef.child(vRef).once("value", snapshot => {
    if (snapshot.exists()) dbRef.child(vRef).remove();
    else alert("FAIL! Video does not exist!");
  });
}

/* helper methods */
function renderVideoList(videos) {
  var header = `
    <tr>
      <th>Id</th>
      <th>Title</th>
      <th>Uploader</th>
      <th>Description</th>
      <th>Tags</th>
      <th>URL</th>
      <th>Timestamp</th>
    </tr>
   `;

  var row = "";
  for (var video of videos) {
    row += `
      <tr onclick = 'lnkID_Click(${video.id})'>
        <td>${video.id}</td>
        <td>${video.title}</td>
        <td>${video.uploader}</td>
        <td>${video.description}</td>
        <td>${video.tags}</td>
        <td>${video.url}</td>
        <td>${video.timestamp}</td>
      </tr>
    `;
  }

  document.getElementById("video-list").innerHTML = header + row;
}

function renderVideoDetails(video) {
  document.getElementById("video-id").value = video.id;
  document.getElementById("video-uploader").value = video.uploader;
  document.getElementById("video-title").value = video.title;
  document.getElementById("video-description").value = video.description;
  document.getElementById("video-tags").value = video.tags;
  document.getElementById("video-url").value = video.url;
  document.getElementById("video-timestamp").value = video.timestamp;
}

function clearTextBoxes() {
  document.getElementById("video-id").value = "";
  document.getElementById("video-uploader").value = "";
  document.getElementById("video-title").value = "";
  document.getElementById("video-description").value = "";
  document.getElementById("video-tags").value = "";
  document.getElementById("video-url").value = "";
  document.getElementById("video-timestamp").value = "";
}
