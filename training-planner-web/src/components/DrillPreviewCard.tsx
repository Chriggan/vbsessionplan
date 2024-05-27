import React from "react";
import { Drill } from "../types/drill";
import {
  Box,
  Button,
  Card,
  CardActions,
  CardContent,
  CardMedia,
  Typography,
} from "@mui/material";

const DrillPreviewCard = ({ drill }: { drill: Drill }) => {
  console.log(drill);

  return (
    <Card sx={{ maxWidth: 345 }}>
      <Box sx={{ display: "flex", flexDirection: "column" }}>
        <CardMedia
          sx={{ height: 140 }}
          image="../../public/favicon.ico"
          title="green iguana"
        />
        <CardContent>
          <Typography gutterBottom variant="h5" component="div">
            {drill.name}
          </Typography>
          <Typography variant="body2" color="text.secondary">
            {drill.description}
          </Typography>
        </CardContent>
      </Box>
      <Box sx={{ display: "flex", flexDirection: "column" }}>
        <CardActions>
          <Button size="small">Share</Button>
          <Button size="small">Learn More</Button>
          <Button size="small">Skills</Button>
        </CardActions>
      </Box>
    </Card>
  );
};

export default DrillPreviewCard;
