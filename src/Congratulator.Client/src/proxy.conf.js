const PROXY_CONFIG = [
  {
    context: [
      "/Congratulator/api/birthdaydate",
      "/Congratulator/api/image",
      "/Congratulator/api/email"
    ],
    target: "https://localhost:7265",
    secure: false
  }
];

module.exports = PROXY_CONFIG;
