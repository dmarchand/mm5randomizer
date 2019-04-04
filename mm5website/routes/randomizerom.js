var express = require('express');
var router = express.Router();
var multer = require('multer');
const util = require('util');
const exec = util.promisify(require('child_process').exec);

var storage = multer.diskStorage({
  destination: function (req, file, cb) {
    cb(null, 'tmp/')
  },
  filename: function (req, file, cb) {
    cb(null, file.fieldname + '-' + Date.now())
  }
})

var uploadService = multer({ storage: storage, limits: { fileSize: 1024 * 1024 * 5 } })
router.get('/randomizer/randomizerom', function(req, res, next) {
  res.render('randomizerom', { title: 'Randomize Mega Man 5' });
});

router.post("/randomizer/randomizerom/upload", uploadService.single('rom'), async function (req, res) {
    var uploadedFile = req.file.path;
    await patchRom(uploadedFile);
    res.download(uploadedFile);
    await rm(uploadedFile);
});

async function patchRom(uploadedFile) {
  const { stdout, stderr } = await exec('dotnet bin/patcher/RandomizerConsole.dll ' + uploadedFile + ' true true true');
  console.log('stdout:', stdout);
  console.log('stderr:', stderr);
}

async function rm(uploadedFile) {
  const { stdout, stderr } = await exec('rm ' + uploadedFile);
}

module.exports = router;
