const proxyCORS = "https://cors-anywhere.herokuapp.com/"; // demo: https://robwu.nl/cors-anywhere.html
const URI = "http://videosa.gear.host/api/videos/";

/* event-handler methods */
function page_Load() {
  getAll();
}

function lnkID_Click(code) {
  getDetails(code);
}

function btnSearch_Click() {
  var keyword = document.getElementById("txtKeyword").value.trim();
  if (keyword.length > 0) search(keyword);
  else getAll();
}

function btnAdd_Click() {
  var newVideo = {
    id: 0,
    uploader: document.getElementById("video-uploader").value,
    title: document.getElementById("video-title").value,
    description: document.getElementById("video-description").value,
    tags: document.getElementById("video-tags").value,
    url: document.getElementById("video-url").value,
    timestamp: document.getElementById("video-timestamp").value
  };
  addNew(newVideo);
}

function btnUpdate_Click() {
  var newVideo = {
    id: document.getElementById("video-id").value,
    uploader: document.getElementById("video-uploader").value,
    title: document.getElementById("video-title").value,
    description: document.getElementById("video-description").value,
    tags: document.getElementById("video-tags").value,
    url: document.getElementById("video-url").value,
    timestamp: document.getElementById("video-timestamp").value
  };
  updateVideo(newVideo);
}

function btnDelete_Click() {
  if (confirm("ARE YOU SURE ?")) {
    var code = document.getElementById("video-id").value;
    deleteVideo(code);
  }
}

/* business methods */
function getAll() {
  addLoadingSpinner(() =>
    axios.get(proxyCORS + URI).then(response => {
      var videos = response.data;
      renderVideoList(videos);
    })
  );
}

function getDetails(code) {
  addLoadingSpinner(() =>
    axios.get(proxyCORS + URI + code).then(response => {
      var video = response.data;
      renderVideoDetails(video);
    })
  );
}

function search(keyword) {
  addLoadingSpinner(() =>
    axios.get(proxyCORS + URI + "title/" + keyword).then(response => {
      var videos = response.data;
      renderVideoList(videos);
    })
  );
}

function addNew(newVideo) {
  addLoadingSpinner(() =>
    axios.post(proxyCORS + URI, newVideo).then(response => {
      var result = response.data;
      if (result) {
        getAll();
        clearTextboxes();
      } else alert("FAILED!");
    })
  );
}

function updateVideo(newVideo) {
  addLoadingSpinner(() =>
    axios.put(proxyCORS + URI, newVideo).then(response => {
      var result = response.data;
      if (result) {
        getAll();
        clearTextboxes();
      } else {
        alert("FAILED!");
      }
    })
  );
}

function deleteVideo(code) {
  addLoadingSpinner(() =>
    axios.delete(proxyCORS + URI + code).then(response => {
      var result = response.data;
      if (result) {
        getAll();
        clearTextboxes();
      } else {
        alert("FAILED!");
      }
    })
  );
}

function addLoadingSpinner(callback) {
  setSpinner(true);
  callback().then(_ => setSpinner(false));
}

/* helper methods */
function renderVideoList(videos) {
  var header = `
  <tr>
    <th>Id</th>
    <th>Uploader</th>
    <th>Title</th>
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

  document.getElementById("videolist").innerHTML = header + row;
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

function clearTextboxes() {
  document.getElementById("video-id").value = "";
  document.getElementById("video-uploader").value = "";
  document.getElementById("video-title").value = "";
  document.getElementById("video-description").value = "";
  document.getElementById("video-tags").value = "";
  document.getElementById("video-url").value = "";
  document.getElementById("video-timestamp").value = "";
}

function setSpinner(visible) {
  if (visible) document.getElementById("loader-wrapper").style.display = "flex";
  else document.getElementById("loader-wrapper").style.display = "none";
}
