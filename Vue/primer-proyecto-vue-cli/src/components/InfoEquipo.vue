<template>
<div>
  <div style="margin-top:3rem">
    <div>
        Team ID: {{id}}
    </div>
    <div>
        Team name: {{teamName}}
    </div>
    <div>
        Team name short: {{teamNameShort}}
    </div>
    <div>
        Team formed year: {{teamFormedYear}}
    </div>
    <div>
        Team sport: {{teamSport}}
    </div>
    <div>
        Team league: {{teamLeague}}
    </div>
  </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  props: {
    id: {
      type: String,
      required: true,
      default: '4387',
    },
  },
  data() {
    return {
      teamData: {},
    };
  },
  computed: {
    teamName() {
      return this.teamData.strTeam
        ? this.teamData.strTeam
        : null;
    },
    teamNameShort() {
      return this.teamData.strTeamShort
        ? this.teamData.strTeamShort
        : null;
    },
    teamFormedYear() {
      return this.teamData.intFormedYear
        ? this.teamData.intFormedYear
        : null;
    },
    teamSport() {
      return this.teamData.strSport
        ? this.teamData.strSport
        : null;
    },
    teamLeague() {
      return this.teamData.strLeague
        ? this.teamData.strLeague
        : null;
    },
  },
  async created() {
    await this.getTeamInfo();
  },
  methods: {
    async getTeamInfo() {
      return axios.get(`https://www.thesportsdb.com/api/v1/json/1/lookup_all_teams.php?id=${this.id}`).then((response) => {
        console.log(response);
        if (response.data.teams) {
          const teamData = response.data.teams[0];
          this.teamData = teamData;
        } else {
          this.teamData = {};
        }
      });
    },
  },
  watch: {
    async id() {
      await this.getTeamInfo();
    },
  },
};
</script>
